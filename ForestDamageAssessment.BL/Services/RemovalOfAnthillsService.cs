using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class RemovalOfAnthillsService : IRemovalOfAnthillsService
    {
        private readonly ITaxPriceRepository _taxPriceRepository;
        private readonly IArticleRepository _articleRepository;
        private const int ArticleID = 14;

        public RemovalOfAnthillsService(ITaxPriceRepository taxPriceRepository, IArticleRepository articleRepository)
        {
            _taxPriceRepository = taxPriceRepository;
            _articleRepository = articleRepository;
        }

        public async Task<RemovalOfAnthillsData> CalculateAsync(string[] diameter, string mainForestBreed, string region)
        {
            var removalOfAnthillsData = new RemovalOfAnthillsData();
            removalOfAnthillsData.ModelList = new List<AnthillViewModel>();
            removalOfAnthillsData.Region = region;
            var culture = new CultureInfo("en-us");

            for (int i = 0; i < diameter.Length; i++)
            {
                double.TryParse(diameter[i], culture, out double currentDiameter);

                var model = new AnthillViewModel
                {
                    MainForestBreed = mainForestBreed,
                    Diameter = currentDiameter,
                };
                removalOfAnthillsData.ModelList.Add(model);
            }

            await CalculateTotalMoneyPunishment(removalOfAnthillsData);
            await GetArticleInfo(removalOfAnthillsData);
            return removalOfAnthillsData;
        }
        private async Task CalculateTotalMoneyPunishment(RemovalOfAnthillsData removalOfAnthillsData)
        {
            foreach (var model in removalOfAnthillsData.ModelList)
            {
                var taxPrice = await _taxPriceRepository.GetTaxPriceAsync(model.MainForestBreed, removalOfAnthillsData.Region);

                if (taxPrice == null)
                {
                    return;
                }

                var culture = new CultureInfo("en-us");
                double.TryParse(taxPrice.PriceLarge, culture, out double priceLarge);

                model.MainForestBreedPrice = priceLarge;
                model.Coeff = GetCoeff(model.Diameter);
                model.Money = model.Coeff * priceLarge;
            }

            removalOfAnthillsData.TotalMoney = removalOfAnthillsData.ModelList.Select(x => x.Money).Sum();
        }
        private async Task GetArticleInfo(RemovalOfAnthillsData? removalOfAnthillsData)
        {
            if (removalOfAnthillsData is null)
            {
                throw new ArgumentNullException(nameof(removalOfAnthillsData));
            }

            removalOfAnthillsData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
        private double GetCoeff(double diameter)
        {
            double coeff = 0;

            if (diameter <= 0.7)
            {
                coeff = 1;
            }
            else if (diameter >= 0.8 && diameter <= 1.0)
            {
                coeff = 1.5;
            }
            else if (diameter >= 1.1 && diameter <= 1.3)
            {
                coeff = 2.5;
            }
            else if (diameter >= 1.4 && diameter <= 1.6)
            {
                coeff = 4.0;
            }
            else if (diameter >= 1.7 && diameter <= 1.9)
            {
                coeff = 6.0;
            }
            else if (diameter >= 2.0)
            {
                coeff = 7.0;
            }

            return coeff;
        }
    }
}