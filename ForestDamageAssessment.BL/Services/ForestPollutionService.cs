using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class ForestPollutionService : IForestPollutionService<ForestPollutionService>
    {
        protected readonly IArticleRepository _articleRepository;
        protected virtual double MainCoefficient { get; } = 5D;
        protected virtual int ArticleID { get; } = 15;

        public ForestPollutionService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ForestPollutionData> CalculateAsync(string priceCleaning)
        {
            var forestPollutionData = new ForestPollutionData();
            var culture = new CultureInfo("en-us");

            double.TryParse(priceCleaning, culture, out double currentPriceCleaning);

            forestPollutionData.Model = new ForestPollutionViewModel { PriceCleaning = currentPriceCleaning };

            CalculateTotalMoneyPunishment(forestPollutionData);
            await GetArticleInfo(forestPollutionData);
            return forestPollutionData;
        }
        private void CalculateTotalMoneyPunishment(ForestPollutionData forestPollutionData)
        {
            var model = forestPollutionData.Model;
            model.Money = model.PriceCleaning;
            forestPollutionData.TotalMoney = model.Money;

            var totalMoneyWithCoeff = forestPollutionData.TotalMoney;
            totalMoneyWithCoeff *= MainCoefficient;
            forestPollutionData.Coefficients.Add($"Коэффициент основной ({MainCoefficient}):", totalMoneyWithCoeff);
        }
        private async Task GetArticleInfo(ForestPollutionData? forestPollutionData)
        {
            if (forestPollutionData is null)
            {
                throw new ArgumentNullException(nameof(forestPollutionData));
            }

            forestPollutionData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
    }
}