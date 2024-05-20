using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class PlacementOfObjectsService : IPlacementOfObjectsService
    {
        private readonly IArticleRepository _articleRepository;
        private const double MainCoefficient = 5D;
        private const int ArticleID = 12;

        public PlacementOfObjectsService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<PlacementOfObjectsData> CalculateAsync(string square, string price, string priceCleaning)
        {
            var placementOfObjectsData = new PlacementOfObjectsData();

            var culture = new CultureInfo("en-us");
            double.TryParse(square, culture, out double currentSquare);
            double.TryParse(price, culture, out double currentPrice);
            double.TryParse(priceCleaning, culture, out double currentPriceCleaning);

            placementOfObjectsData.Model = new ObjectViewModel { Square = currentSquare, Price = currentPrice, PriceCleaning = currentPriceCleaning };

            CalculateTotalMoneyPunishment(placementOfObjectsData);
            await GetArticleInfo(placementOfObjectsData);
            return placementOfObjectsData;
        }
        private void CalculateTotalMoneyPunishment(PlacementOfObjectsData placementOfObjectsData)
        {
            var model = placementOfObjectsData.Model;
            model.Money = model.Square * model.Price + model.Square * model.PriceCleaning;
            placementOfObjectsData.TotalMoney = model.Money;

            var totalMoneyWithCoeff = placementOfObjectsData.TotalMoney;
            totalMoneyWithCoeff *= MainCoefficient;
            placementOfObjectsData.Coefficients.Add($"Коэффициент основной ({MainCoefficient}):", totalMoneyWithCoeff);
        }
        private async Task GetArticleInfo(PlacementOfObjectsData? placementOfObjectsData)
        {
            if (placementOfObjectsData is null)
            {
                throw new ArgumentNullException(nameof(placementOfObjectsData));
            }

            placementOfObjectsData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
    }
}