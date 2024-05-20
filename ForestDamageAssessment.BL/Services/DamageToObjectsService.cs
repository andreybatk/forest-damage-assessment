using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class DamageToObjectsService : IDamageToObjectsService
    {
        private readonly IArticleRepository _articleRepository;
        private const double MainCoefficient = 2D;
        private const int ArticleID = 18;

        public DamageToObjectsService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<DamageToObjectsData> CalculateAsync(string price)
        {
            var damageToObjectsData = new DamageToObjectsData();

            var culture = new CultureInfo("en-us");
            double.TryParse(price, culture, out double currentPrice);

            damageToObjectsData.Model = new DamageToObjectsViewModel { Price = currentPrice };

            CalculateTotalMoneyPunishment(damageToObjectsData);
            await GetArticleInfo(damageToObjectsData);
            return damageToObjectsData;
        }
        private void CalculateTotalMoneyPunishment(DamageToObjectsData damageToObjectsData)
        {
            var model = damageToObjectsData.Model;
            model.Money = model.Price;

            damageToObjectsData.TotalMoney = model.Money;

            var totalMoneyWithCoeff = damageToObjectsData.TotalMoney;
            totalMoneyWithCoeff *= MainCoefficient;
            damageToObjectsData.Coefficients.Add($"Коэффициент основной ({MainCoefficient}):", totalMoneyWithCoeff);
        }
        private async Task GetArticleInfo(DamageToObjectsData? damageToObjectsData)
        {
            if (damageToObjectsData is null)
            {
                throw new ArgumentNullException(nameof(damageToObjectsData));
            }

            damageToObjectsData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
    }
}