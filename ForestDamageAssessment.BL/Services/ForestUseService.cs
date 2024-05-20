using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class ForestUseService : IForestUseService
    {
        private readonly ITaxPriceForestUseRepository _taxPriceForestUseRepository;
        private readonly IArticleRepository _articleRepository;
        private const double MainCoefficient = 5D;
        private const int ArticleID = 11;

        public ForestUseService(ITaxPriceForestUseRepository taxPriceForestUseRepository, IArticleRepository articleRepository)
        {
            _taxPriceForestUseRepository = taxPriceForestUseRepository;
            _articleRepository = articleRepository;
        }

        public async Task<ForestUseData> CalculateAsync(string square, string price, bool isViolation1, bool isViolation2, bool isViolation3, string region)
        {
            var forestUseData = new ForestUseData();
            forestUseData.Region = region;

            var culture = new CultureInfo("en-us");
            double.TryParse(square, culture, out double currentSquare);
            double.TryParse(price, culture, out double currentPrice);

            forestUseData.Model = new ForestUseViewModel
            {
                Square = currentSquare,
                Price = currentPrice,
                IsViolation1 = isViolation1,
                IsViolation2 = isViolation2,
                IsViolation3 = isViolation3,
            };

            await CalculateTotalMoneyPunishment(forestUseData);
            await GetArticleInfo(forestUseData);
            return forestUseData;
        }
        private async Task CalculateTotalMoneyPunishment(ForestUseData forestUseData)
        {
            var taxPrice = await _taxPriceForestUseRepository.GetTaxPriceAsync(forestUseData.Region);
            var model = forestUseData.Model;

            if (taxPrice == null)
            {
                return;
            }

            var culture = new CultureInfo("en-us");
            double.TryParse(taxPrice.Violation1Price, culture, out double violation1Price);
            double.TryParse(taxPrice.Violation2Price, culture, out double violation2Price);
            double.TryParse(taxPrice.Violation3Price, culture, out double violation3Price);

            model.Violation1Price = violation1Price;
            model.Violation2Price = violation2Price;
            model.Violation3Price = violation3Price;

            model.Money = model.Square * model.Price;

            if (model.IsViolation1)
            {
                model.Money += model.Square * violation1Price;
            }

            if (model.IsViolation2)
            {
                model.Money += model.Square * violation2Price;
            }

            if (model.IsViolation3)
            {
                model.Money += model.Square * violation3Price;
            }

            forestUseData.TotalMoney = model.Money;

            var totalMoneyWithCoeff = forestUseData.TotalMoney;
            totalMoneyWithCoeff *= MainCoefficient;
            forestUseData.Coefficients.Add($"Коэффициент основной ({MainCoefficient}):", totalMoneyWithCoeff);
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