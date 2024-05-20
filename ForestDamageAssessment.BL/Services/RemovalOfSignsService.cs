using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class RemovalOfSignsService : IRemovalOfSignsService
    {
        private readonly IArticleRepository _articleRepository;
        private const double MainCoefficient = 5D;
        private const int ArticleID = 17;

        public RemovalOfSignsService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<RemovalOfSignsData> CalculateAsync(string price)
        {
            var removalOfSignsData = new RemovalOfSignsData();
            var culture = new CultureInfo("en-us");
            double.TryParse(price, culture, out double currentPrice);

            removalOfSignsData.Model = new SignViewModel { Price = currentPrice };

            CalculateTotalMoneyPunishment(removalOfSignsData);
            await GetArticleInfo(removalOfSignsData);
            return removalOfSignsData;
        }
        private void CalculateTotalMoneyPunishment(RemovalOfSignsData removalOfSignsData)
        {
            var model = removalOfSignsData.Model;
            model.Money = model.Price;
            removalOfSignsData.TotalMoney = model.Money;

            var totalMoneyWithCoeff = removalOfSignsData.TotalMoney;
            totalMoneyWithCoeff *= MainCoefficient;
            removalOfSignsData.Coefficients.Add($"Коэффициент основной ({MainCoefficient}):", totalMoneyWithCoeff);
        }
        private async Task GetArticleInfo(RemovalOfSignsData? removalOfSignsData)
        {
            if (removalOfSignsData is null)
            {
                throw new ArgumentNullException(nameof(removalOfSignsData));
            }

            removalOfSignsData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
    }
}