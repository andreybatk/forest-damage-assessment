using ForestDamageAssessment.BL.Abstractions;
using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class DeadFellingViolationService : ViolationServiceBase, IViolationService<DeadFellingViolationService, ITreeViewModel>
    {
        private readonly ITaxPriceRepository _taxPriceRepository;
        private readonly ISTDRepository _sTDRepository;

        public DeadFellingViolationService(ITaxPriceRepository taxPriceRepository, ISTDRepository sTDRepository, IAssortmentRepository assortmentRepository, IArticleRepository articleRepository)
            : base(assortmentRepository, articleRepository)
        {
            _taxPriceRepository = taxPriceRepository;
            _sTDRepository = sTDRepository;
        }

        protected override int ArticleID => 5;

        public async Task<ForestArea<ITreeViewModel>> CalculateAsync(ForestArea<ITreeViewModel> forestArea)
        {
            await GetArticleInfo(forestArea.ForestData);
            await CalculateDiameterAsync(forestArea.ModelList);
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
            catch (Exception ex)
            {
                //TODO LOGGER
            }
        }
        private async Task CalculateDiameterAsync(List<ITreeViewModel>? modelList)
        {
            if (modelList is null)
            {
                throw new ArgumentNullException(nameof(modelList));
            }
            try
            {
                foreach (var model in modelList)
                {
                    model.CalculatedDiameter = model.Diameter;
                    model.ThicknessLevel = await GetThicknessLevelAsync(model.Diameter);
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