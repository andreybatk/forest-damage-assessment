﻿using ForestDamageAssessment.BL.Abstractions;
using ForestDamageAssessment.BL.Exceptions;
using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class TreeFellingViolationService : ViolationServiceBase, IExtendedViolationService<TreeFellingViolationService, ITreeViewModel>
    {
        private readonly ITaxPriceRepository _taxPriceRepository;
        private readonly IBreedDiameterModelRepository _breedDiameterModelRepository;
        private readonly ISTDRepository _sTDRepository;

        public TreeFellingViolationService(IAssortmentRepository assortmentRepository, ITaxPriceRepository taxPriceRepository, IBreedDiameterModelRepository breedDiameterModelRepository, ISTDRepository sTDRepository, IArticleRepository articleRepository)
            : base(assortmentRepository, articleRepository)
        {
            _taxPriceRepository = taxPriceRepository;
            _breedDiameterModelRepository = breedDiameterModelRepository;
            _sTDRepository = sTDRepository;
        }

        public async Task<ForestArea<ITreeViewModel>> CalculateAsync(ForestArea<ITreeViewModel> forestArea)
        {
            await GetArticleInfo(forestArea.ForestData);
            await CalculateDiameterAsync(forestArea.ModelList, forestArea.ForestData.Year);
            await CalculateStockAsync(forestArea.ModelList);
            await CalculateMoneyPunishmentAsync(forestArea);
            CalculateTotalMoneyPunishment(forestArea.ModelList, forestArea.ForestData);

            return forestArea;
        }
        public async Task<ForestArea<ITreeViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestArea<ITreeViewModel> forestArea)
        {
            forestArea.ModelList = new List<ITreeViewModel>();
            var culture = new CultureInfo("en-us");

            if (fileModel is null)
            {
                throw new ArgumentNullException(nameof(fileModel));
            }

            if (!File.Exists(fileModel.Path))
            {
                throw new FileNotFoundException(nameof(fileModel));
            }

            try
            {
                using (StreamReader reader = new StreamReader(fileModel.Path))
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        var data = line.Trim(';').Split(';');

                        if (data.Length != 4)
                        {
                            throw new FileModelFormatDataException(nameof(fileModel));
                        }

                        double.TryParse(data[1], culture, out double resultDiameter);
                        double.TryParse(data[2], culture, out double resultH);
                        double.TryParse(data[3], culture, out double resultRankH);

                        var viewModel = new TreeViewModel { Breed = data[0], Diameter = resultDiameter, H = resultH, RankH = resultRankH };
                        forestArea.ModelList.Add(viewModel);
                    }
                }
            }
            catch (Exception)
            {
                //TODO LOGGER
            }

            await GetArticleInfo(forestArea.ForestData);
            await CalculateDiameterAsync(forestArea.ModelList, forestArea.ForestData.Year);
            await CalculateStockAsync(forestArea.ModelList);
            await CalculateMoneyPunishmentAsync(forestArea);
            CalculateTotalMoneyPunishment(forestArea.ModelList, forestArea.ForestData);

            return forestArea;
        }
        private async Task CalculateMoneyPunishmentAsync(ForestArea<ITreeViewModel> forestArea)
        {
            if (forestArea.ModelList is null)
            {
                throw new ArgumentNullException(nameof(forestArea.ModelList));
            }
            try
            {
                foreach (var model in forestArea.ModelList)
                {
                    var taxPrice = await _taxPriceRepository.GetTaxPriceAsync(model.Breed, forestArea.ForestData.Region);

                    if (taxPrice == null)
                    {
                        continue;
                    }

                    var culture = new CultureInfo("en-us");
                    double.TryParse(taxPrice.PriceAverage, culture, out double priceAverage);
                    double.TryParse(taxPrice.PriceLarge, culture, out double priceLarge);
                    double.TryParse(taxPrice.PriceSmall, culture, out double priceSmall);
                    double.TryParse(taxPrice.Firewood, culture, out double priceFirewood);

                    model.Money.TaxPriceSmall = priceSmall;
                    model.Money.TaxPriceLarge = priceLarge;
                    model.Money.TaxPriceAverage = priceAverage;
                    model.Money.TaxPriceFirewood = priceFirewood;
                    model.Money.Large = priceAverage * model.Stock.SumAverage;
                    model.Money.Average = priceLarge * model.Stock.SumLarge;
                    model.Money.Small = priceSmall * model.Stock.SumSmall;
                    model.Money.Business = model.Money.Large + model.Money.Average + model.Money.Small;
                    model.Money.Firewood = priceFirewood * model.Stock.SumFirewood;
                    model.Money.BusinessAndFirewood = model.Money.Business + model.Money.Firewood;
                }
            }
            catch (Exception)
            {
                //TODO LOGGER
            }
        }
        private async Task CalculateDiameterAsync(List<ITreeViewModel>? modelList, string year)
        {
            if (modelList is null)
            {
                throw new ArgumentNullException(nameof(modelList));
            }
            try
            {
                foreach (var model in modelList)
                {
                    int.TryParse(year, out int currentYear);

                    if (currentYear < 2019)
                    {
                        var breedDiameter = await _breedDiameterModelRepository.GetBreedDiameterModelAsync(model.Breed);

                        if (breedDiameter == null)
                        {
                            continue;
                        }

                        double DimeterPercent =
                            double.Parse(breedDiameter.C1) * Math.Pow(model.H, double.Parse(breedDiameter.C2))
                            - double.Parse(breedDiameter.C3) * Math.Exp(-double.Parse(breedDiameter.C4) * model.H);

                        model.CalculatedDiameter = Math.Round(model.Diameter * 100 / DimeterPercent);
                        model.ThicknessLevel = await GetThicknessLevelAsync(model.CalculatedDiameter);
                    }
                    else
                    {
                        model.CalculatedDiameter = model.Diameter;
                        model.ThicknessLevel = await GetThicknessLevelAsync(model.Diameter);
                    }
                }
            }
            catch (Exception)
            {
                //TODO LOGGER
            }
        }
        private async Task<int?> GetThicknessLevelAsync(double diameter)
        {
            if (diameter == 0)
            {
                return null;
            }

            var thicknessLevel = await _sTDRepository.GetSTDAsync(diameter);
            return thicknessLevel?.ThicknessLevel;
        }
    }
}