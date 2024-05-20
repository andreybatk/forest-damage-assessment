using ForestDamageAssessment.BL.Abstractions;
using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Repositories;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class DeadFellingViolationService : ViolationServiceBase, IViolationService<DeadFellingViolationService, ITreeViewModel>
    {
        private readonly ITaxPriceRepository _taxPriceRepository;
        private readonly ISTDRepository _sTDRepository;
        private readonly IBreedDiameterModelRepository _breedDiameterModelRepository;

        public DeadFellingViolationService(ITaxPriceRepository taxPriceRepository, ISTDRepository sTDRepository, IAssortmentRepository assortmentRepository, IArticleRepository articleRepository, IBreedDiameterModelRepository breedDiameterModelRepository)
            : base(assortmentRepository, articleRepository)
        {
            _taxPriceRepository = taxPriceRepository;
            _sTDRepository = sTDRepository;
            _breedDiameterModelRepository = breedDiameterModelRepository;
        }

        protected override int ArticleID => 5;

        public async Task<ForestArea<ITreeViewModel>> CalculateAsync(ForestArea<ITreeViewModel> forestArea)
        {
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
                    var culture = new CultureInfo("en-us");

                    if (taxPrice == null)
                    {
                        continue;
                    }

                    double.TryParse(taxPrice.Firewood, culture, out double priceFirewood);
                    model.Money.TaxPriceFirewood = priceFirewood;
                    model.Money.Firewood = priceFirewood * model.Stock.SumFirewood;
                    model.Money.BusinessAndFirewood = model.Money.Firewood;
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