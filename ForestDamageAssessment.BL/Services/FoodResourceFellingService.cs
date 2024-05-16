using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class FoodResourceFellingService : IFoodResourceFellingService
    {
        private readonly ITaxPriceFoodResourceRepository _taxPriceFoodResourceRepository;
        private readonly IArticleRepository _articleRepository;
        private const double MainCoefficient = 2D;
        private const int ArticleID = 10;

        public FoodResourceFellingService(ITaxPriceFoodResourceRepository taxPriceFoodResourceRepository, IArticleRepository articleRepository)
        {
            _taxPriceFoodResourceRepository = taxPriceFoodResourceRepository;
            _articleRepository = articleRepository;
        }

        public async Task<FoodResourceData> CalculateAsync(string[] treeSap, string[] wildFuits, string[] wildBerries, string[] wildMushrooms, string[] wildNuts,
            string[] seeds, string[] medicinalPlants, string region)
        {
            var foodResourceData = new FoodResourceData();
            foodResourceData.Region = region;

            foodResourceData.ModelList = new List<FoodResourceViewModel>();
            var culture = new CultureInfo("en-us");

            for (int i = 0; i < treeSap.Length; i++)
            {
                double.TryParse(treeSap[i], culture, out double currentTreeSap);
                double.TryParse(wildFuits[i], culture, out double currentWildFuits);
                double.TryParse(wildBerries[i], culture, out double currentWildBerries);
                double.TryParse(wildMushrooms[i], culture, out double currentWildMushrooms);
                double.TryParse(wildNuts[i], culture, out double currentWildNuts);
                double.TryParse(seeds[i], culture, out double currentSeeds);
                double.TryParse(medicinalPlants[i], culture, out double currentMedicinalPlants);

                var model = new FoodResourceViewModel
                {
                    TreeSap = currentTreeSap,
                    WildFuits = currentWildFuits,
                    WildBerries = currentWildBerries,
                    WildMushrooms = currentWildMushrooms,
                    WildNuts = currentWildNuts,
                    Seeds = currentSeeds,
                    MedicinalPlants = currentMedicinalPlants
                };
                foodResourceData.ModelList.Add(model);
            }

            await CalculateTotalMoneyPunishment(foodResourceData);
            await GetArticleInfo(foodResourceData);
            return foodResourceData;
        }
        private async Task CalculateTotalMoneyPunishment(FoodResourceData foodResourceData)
        {
            foreach (var forest in foodResourceData.ModelList)
            {
                var taxPrice = await _taxPriceFoodResourceRepository.GetTaxPriceAsync(foodResourceData.Region);
                var culture = new CultureInfo("en-us");

                if (taxPrice == null)
                {
                    continue;
                }

                double.TryParse(taxPrice.TreeSapPrice, culture, out double treeSapPrice);
                double.TryParse(taxPrice.WildFuitsPrice, culture, out double wildFuitsPrice);
                double.TryParse(taxPrice.WildBerriesPrice, culture, out double wildBerriesPrice);
                double.TryParse(taxPrice.WildMushroomsPrice, culture, out double wildMushroomsPrice);
                double.TryParse(taxPrice.WildNutsPrice, culture, out double wildNutsPrice);
                double.TryParse(taxPrice.SeedsPrice, culture, out double seedsPrice);
                double.TryParse(taxPrice.MedicinalPlantsPrice, culture, out double medicinalPlantsPrice);

                forest.TreeSapPrice = treeSapPrice;
                forest.WildFuitsPrice = wildFuitsPrice;
                forest.WildBerriesPrice = wildBerriesPrice;
                forest.WildMushroomsPrice = wildMushroomsPrice;
                forest.WildNutsPrice = wildNutsPrice;
                forest.SeedsPrice = seedsPrice;
                forest.MedicinalPlantsPrice = medicinalPlantsPrice;

                forest.Money = forest.TreeSap * treeSapPrice + forest.WildFuits * wildFuitsPrice + forest.WildBerries * wildBerriesPrice +
                    forest.WildMushrooms * wildMushroomsPrice + forest.WildNuts * wildNutsPrice + forest.Seeds * seedsPrice + forest.MedicinalPlants * medicinalPlantsPrice;
            }
            foodResourceData.TotalMoney = foodResourceData.ModelList.Select(x => x.Money).Sum();

            var totalMoneyWithCoeff = foodResourceData.TotalMoney;
            totalMoneyWithCoeff *= MainCoefficient;
            foodResourceData.Coefficients.Add($"Коэффициент основной ({MainCoefficient}):", totalMoneyWithCoeff);
        }
        private async Task GetArticleInfo(FoodResourceData? foodResourceData)
        {
            if (foodResourceData is null)
            {
                throw new ArgumentNullException(nameof(foodResourceData));
            }

            foodResourceData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
    }
}
