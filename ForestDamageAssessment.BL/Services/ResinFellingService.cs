using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class ResinFellingService : IResinFellingService
    {
        private readonly ITaxPriceResinRepository _taxPriceResinRepository;
        private readonly IArticleRepository _articleRepository;
        private const double MainCoefficient = 5D;
        private const int ArticleID = 8;

        public ResinFellingService(ITaxPriceResinRepository taxPriceResinRepository, IArticleRepository articleRepository)
        {
            _taxPriceResinRepository = taxPriceResinRepository;
            _articleRepository = articleRepository;
        }

        public async Task<ResinData> CalculateAsync(string[] countTon, string[] breed, string region)
        {
            var resinData = new ResinData();
            resinData.ModelList = new List<ResinViewModel>();
            resinData.Region = region;
            var culture = new CultureInfo("en-us");

            for (int i = 0; i < countTon.Length; i++)
            {
                double.TryParse(countTon[i], culture, out double currentCountTon);
                var model = new ResinViewModel { CountTon = currentCountTon, Breed = breed[i] };
                resinData.ModelList.Add(model);
            }

            await CalculateTotalMoneyPunishment(resinData);
            await GetArticleInfo(resinData);
            return resinData;
        }
        private async Task CalculateTotalMoneyPunishment(ResinData resinData)
        {
            foreach (var resin in resinData.ModelList)
            {
                var taxPrice = await _taxPriceResinRepository.GetTaxPriceAsync(resin.Breed, resinData.Region);

                if (taxPrice == null)
                {
                    continue;
                }

                var culture = new CultureInfo("en-us");
                double.TryParse(taxPrice.Price, culture, out double price);
                resin.Price = price;
                resin.Money = resin.CountTon * price;
            }
            resinData.TotalMoney = resinData.ModelList.Select(x => x.Money).Sum();

            var totalMoneyWithCoeff = resinData.TotalMoney;
            totalMoneyWithCoeff *= MainCoefficient;
            resinData.Coefficients.Add($"Коэффициент основной ({MainCoefficient}):", totalMoneyWithCoeff);
        }
        private async Task GetArticleInfo(ResinData? resinData)
        {
            if (resinData is null)
            {
                throw new ArgumentNullException(nameof(resinData));
            }

            resinData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
    }
}