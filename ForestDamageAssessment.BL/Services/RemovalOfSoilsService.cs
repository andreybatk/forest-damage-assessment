using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class RemovalOfSoilsService : IRemovalOfSoilsService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ITaxPriceRepository _taxPriceRepository;
        private const double MainCoefficient = 4D;
        private const int ArticleID = 13;

        public RemovalOfSoilsService(IArticleRepository articleRepository, ITaxPriceRepository taxPriceRepository)
        {
            _articleRepository = articleRepository;
            _taxPriceRepository = taxPriceRepository;
        }

        public async Task<RemovalOfSoilsData> CalculateAsync(string square, int vehicleCount, string mainForestBreed, string region)
        {
            var removalOfSoilsData = new RemovalOfSoilsData();
            removalOfSoilsData.Region = region;

            var culture = new CultureInfo("en-us");
            double.TryParse(square, culture, out double currentSquare);

            removalOfSoilsData.Model = new SoilViewModel { Square = currentSquare, MainForestBreed = mainForestBreed, VehicleCount = vehicleCount };

            await CalculateTotalMoneyPunishment(removalOfSoilsData);
            await GetArticleInfo(removalOfSoilsData);
            return removalOfSoilsData;
        }
        private async Task CalculateTotalMoneyPunishment(RemovalOfSoilsData removalOfSoilsData)
        {
            var model = removalOfSoilsData.Model;
            var taxPrice = await _taxPriceRepository.GetTaxPriceAsync(model.MainForestBreed, removalOfSoilsData.Region);

            if (taxPrice == null)
            {
                return;
            }

            var culture = new CultureInfo("en-us");
            double.TryParse(taxPrice.PriceLarge, culture, out double priceLarge);

            model.MainForestBreedPrice = priceLarge;
            model.Money = model.Square * priceLarge + model.VehicleCount * priceLarge;
            removalOfSoilsData.TotalMoney = model.Money;

            var totalMoneyWithCoeff = removalOfSoilsData.TotalMoney;
            totalMoneyWithCoeff *= MainCoefficient;
            removalOfSoilsData.Coefficients.Add($"Коэффициент основной ({MainCoefficient}):", totalMoneyWithCoeff);
        }
        private async Task GetArticleInfo(RemovalOfSoilsData? removalOfSoilsData)
        {
            if (removalOfSoilsData is null)
            {
                throw new ArgumentNullException(nameof(removalOfSoilsData));
            }

            removalOfSoilsData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
    }
}