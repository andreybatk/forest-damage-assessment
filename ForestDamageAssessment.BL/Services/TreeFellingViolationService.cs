﻿using ForestDamageAssessment.BL.Abstractions;
using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class TreeFellingViolationService : ViolationService, IViolationService<TreeFellingViolationService, ITreeViewModel>
    {
        private readonly ITaxPriceRepository _taxPriceRepository;
        private readonly IBreedDiameterModelRepository _breedDiameterModelRepository;
        private readonly ISTDRepository _sTDRepository;

        public TreeFellingViolationService(IAssortmentRepository assortmentRepository, ITaxPriceRepository taxPriceRepository, IBreedDiameterModelRepository breedDiameterModelRepository, ISTDRepository sTDRepository)
            : base(assortmentRepository)
        {
            _taxPriceRepository = taxPriceRepository;
            _breedDiameterModelRepository = breedDiameterModelRepository;
            _sTDRepository = sTDRepository;
        }

        public async Task<ForestAreaModel<ITreeViewModel>> CalculateAsync(ForestAreaModel<ITreeViewModel> forestArea)
        {
            await CalculateDiameterAsync(forestArea.ModelList);
            await CalculateStockAsync(forestArea.ModelList);
            await CalculateMoneyPunishmentAsync(forestArea);
            CalculateTotalMoneyPunishment(forestArea.ModelList, forestArea.ForestData);

            return forestArea;
        }
        public async Task<ForestAreaModel<ITreeViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestAreaModel<ITreeViewModel> forestArea)
        {
            forestArea.ModelList = new List<ITreeViewModel>();
            var culture = new CultureInfo("en-us");

            if (fileModel == null)
            {
                return forestArea;
            }

            using (StreamReader reader = new StreamReader(fileModel.Path))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var data = line.Split(';');
                    if (data.Length < 3)
                    {
                        continue;
                    }
                    double.TryParse(data[1], culture, out double resultDiameter);
                    double.TryParse(data[2], culture, out double resultH);
                    double.TryParse(data[3], culture, out double resultRankH);

                    var viewModel = new TreeViewModel { Breed = data[0], Diameter = resultDiameter, H = resultH, RankH = resultRankH };
                    forestArea.ModelList.Add(viewModel);
                }
            }

            await CalculateDiameterAsync(forestArea.ModelList);
            await CalculateStockAsync(forestArea.ModelList);
            await CalculateMoneyPunishmentAsync(forestArea);
            CalculateTotalMoneyPunishment(forestArea.ModelList, forestArea.ForestData);

            return forestArea;
        }
        private async Task CalculateMoneyPunishmentAsync(ForestAreaModel<ITreeViewModel> forestArea)
        {
            try
            {
                if (forestArea.ModelList == null)
                {
                    return;
                }

                foreach (var model in forestArea.ModelList)
                {
                    var taxPrice = await _taxPriceRepository.GetTaxPriceAsync(model.Breed, forestArea.ForestData.Region);

                    if (taxPrice == null)
                    {
                        continue;
                    }

                    var culture = new CultureInfo("en-us");

                    double.TryParse(taxPrice.PriceAverage, culture, out double priceAverage);
                    double.TryParse(taxPrice.Firewood, culture, out double priceFirewood);

                    model.Money.TaxPriceBusiness = priceAverage;
                    model.Money.TaxPriceFirewood = priceFirewood;
                    model.Money.Business = priceAverage * model.Stock.SumBusiness;
                    model.Money.Firewood = priceFirewood * model.Stock.SumFirewood;
                    model.Money.BusinessAndFirewood = model.Money.Business + model.Money.Firewood;
                }
            }
            catch (Exception ex)
            {
                //TODO LOGGER
            }
        }
        private async Task CalculateDiameterAsync(List<ITreeViewModel>? modelList)
        {
            try
            {
                if (modelList == null)
                {
                    return;
                }

                foreach (var model in modelList)
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
            }
            catch (Exception ex)
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