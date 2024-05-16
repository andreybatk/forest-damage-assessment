using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class ForestUseFellingService : IForestUseFellingService
    {
        private readonly ITaxPriceForestUseRepository _taxPriceForestUseRepository;
        private readonly IArticleRepository _articleRepository;
        private const double MainCoefficient = 5D;
        private const int ArticleID = 11;

        public ForestUseFellingService(ITaxPriceForestUseRepository taxPriceForestUseRepository, IArticleRepository articleRepository)
        {
            _taxPriceForestUseRepository = taxPriceForestUseRepository;
            _articleRepository = articleRepository;
        }

        public async Task<ForestUseData> CalculateAsync(string[] square, string[] price, bool isViolation1, bool isViolation2, bool isViolation3, string region)
        {
            var forestUseData = new ForestUseData();
            forestUseData.Region = region;

            forestUseData.ModelList = new List<ForestUseViewModel>();
            var culture = new CultureInfo("en-us");

            for (int i = 0; i < square.Length; i++)
            {
                double.TryParse(square[i], culture, out double currentSquare);
                double.TryParse(price[i], culture, out double currentPrice);

                var model = new ForestUseViewModel
                {
                    Square = currentSquare,
                    Price = currentPrice,
                    IsViolation1 = isViolation1,
                    IsViolation2 = isViolation2,
                    IsViolation3 = isViolation3,
                };
                forestUseData.ModelList.Add(model);
            }

            await CalculateTotalMoneyPunishment(forestUseData);
            await GetArticleInfo(forestUseData);
            return forestUseData;
        }
        private async Task CalculateTotalMoneyPunishment(ForestUseData forestUseData)
        {
            foreach (var forest in forestUseData.ModelList)
            {
                var taxPrice = await _taxPriceForestUseRepository.GetTaxPriceAsync(forestUseData.Region);
                var culture = new CultureInfo("en-us");

                if (taxPrice == null)
                {
                    continue;
                }

                double.TryParse(taxPrice.Violation1Price, culture, out double violation1Price);
                double.TryParse(taxPrice.Violation2Price, culture, out double violation2Price);
                double.TryParse(taxPrice.Violation3Price, culture, out double violation3Price);

                forest.Violation1Price = violation1Price;
                forest.Violation2Price = violation2Price;
                forest.Violation3Price = violation3Price;

                forest.Money = forest.Square * forest.Price;

                if (forest.IsViolation1)
                {
                    forest.Money += forest.Square * violation1Price;
                }

                if (forest.IsViolation2)
                {
                    forest.Money += forest.Square * violation2Price;
                }

                if (forest.IsViolation3)
                {
                    forest.Money += forest.Square * violation3Price;
                }

                forestUseData.TotalMoney = forestUseData.ModelList.Select(x => x.Money).Sum();

                var totalMoneyWithCoeff = forestUseData.TotalMoney;
                totalMoneyWithCoeff *= MainCoefficient;
                forestUseData.Coefficients.Add($"Коэффициент основной ({MainCoefficient}):", totalMoneyWithCoeff);
            }
        }
        private async Task GetArticleInfo(ForestUseData? forestUseData)
        {
            if (forestUseData is null)
            {
                throw new ArgumentNullException(nameof(forestUseData));
            }

            forestUseData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
    }
}