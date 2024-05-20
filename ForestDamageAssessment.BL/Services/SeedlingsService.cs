using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class SeedlingsService : ISeedlingsService
    {
        private readonly IArticleRepository _articleRepository;
        private const double MainCoefficient = 5D;
        private const int ArticleID = 6;

        public SeedlingsService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<SeedlingData> CalculateAsync(int[] count, string[] breed, string[] price)
        {
            var seedlingData = new SeedlingData();
            seedlingData.ModelList = new List<SeedViewModel>();
            var culture = new CultureInfo("en-us");

            for (int i = 0; i < count.Length; i++)
            {
                double.TryParse(price[i], culture, out double currentPrice);
                var money = currentPrice * Convert.ToDouble(count[i]);
                var model = new SeedViewModel { Count = count[i], Breed = breed[i], Price = currentPrice, Money = money };
                seedlingData.ModelList.Add(model);
            }

            CalculateTotalMoneyPunishment(seedlingData);
            await GetArticleInfo(seedlingData);
            return seedlingData;
        }
        private void CalculateTotalMoneyPunishment(SeedlingData seedlingData)
        {
            seedlingData.TotalMoney = seedlingData.ModelList.Select(x => x.Money).Sum();

            var totalMoneyWithCoeff = seedlingData.TotalMoney;
            totalMoneyWithCoeff *= MainCoefficient;
            seedlingData.Coefficients.Add($"Коэффициент основной ({MainCoefficient}):", totalMoneyWithCoeff);
        }
        private async Task GetArticleInfo(SeedlingData? seedlingData)
        {
            if (seedlingData is null)
            {
                throw new ArgumentNullException(nameof(seedlingData));
            }

            seedlingData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
    }
}