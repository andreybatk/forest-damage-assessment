using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class ForestResourceFellingService : IForestResourceFellingService
    {
        private readonly ITaxPriceForestResourceRepository _taxPriceForestResourceRepository;
        private readonly IArticleRepository _articleRepository;
        private const double MainCoefficient = 2D;
        private const int ArticleID = 9;

        public ForestResourceFellingService(ITaxPriceForestResourceRepository taxPriceForestResourceRepository, IArticleRepository articleRepository)
        {
            _taxPriceForestResourceRepository = taxPriceForestResourceRepository;
            _articleRepository = articleRepository;
        }

        public async Task<ForestResourceData> CalculateAsync(string[] stumps, string[] bark, string[] lub, string[] birchBark, string[] firPaw,
            string[] pinePaw, string[] sprucePaw, string[] brushwood, string[] forestFloor, string region)
        {
            var forestResourceData = new ForestResourceData();
            forestResourceData.Region = region;

            forestResourceData.ModelList = new List<ForestResourceViewModel>();
            var culture = new CultureInfo("en-us");

            for (int i = 0; i < stumps.Length; i++)
            {
                double.TryParse(stumps[i], culture, out double currentStumps);
                double.TryParse(bark[i], culture, out double currentBark);
                double.TryParse(lub[i], culture, out double currentLub);
                double.TryParse(birchBark[i], culture, out double currentBirchBark);
                double.TryParse(firPaw[i], culture, out double currentFirPaw);
                double.TryParse(pinePaw[i], culture, out double currentPinePaw);
                double.TryParse(sprucePaw[i], culture, out double currentSprucePaw);
                double.TryParse(brushwood[i], culture, out double currentBrushwood);
                double.TryParse(forestFloor[i], culture, out double currentForestFloor);

                var model = new ForestResourceViewModel
                {
                    Stumps = currentStumps,
                    Bark = currentBark,
                    Lub = currentLub,
                    BirchBark = currentBirchBark,
                    FirPaw = currentFirPaw,
                    PinePaw = currentPinePaw,
                    SprucePaw = currentSprucePaw,
                    Brushwood = currentBrushwood,
                    ForestFloor = currentForestFloor
                };
                forestResourceData.ModelList.Add(model);
            }

            await CalculateTotalMoneyPunishment(forestResourceData);
            await GetArticleInfo(forestResourceData);
            return forestResourceData;
        }
        private async Task CalculateTotalMoneyPunishment(ForestResourceData forestResourceData)
        {
            foreach (var forest in forestResourceData.ModelList)
            {
                var taxPrice = await _taxPriceForestResourceRepository.GetTaxPriceAsync(forestResourceData.Region);
                var culture = new CultureInfo("en-us");

                if (taxPrice == null)
                {
                    continue;
                }

                double.TryParse(taxPrice.StumpsPrice, culture, out double stumpsPrice);
                double.TryParse(taxPrice.BarkPrice, culture, out double barkPrice);
                double.TryParse(taxPrice.LubPrice, culture, out double lubPrice);
                double.TryParse(taxPrice.BirchBarkPrice, culture, out double birchBarkPrice);
                double.TryParse(taxPrice.FirPawPrice, culture, out double firPawPrice);
                double.TryParse(taxPrice.PinePawPrice, culture, out double pinePawPrice);
                double.TryParse(taxPrice.SprucePawPrice, culture, out double sprucePawPrice);
                double.TryParse(taxPrice.BrushwoodPrice, culture, out double brushwoodPrice);
                double.TryParse(taxPrice.ForestFloorPrice, culture, out double forestFloorPrice);

                forest.StumpsPrice = stumpsPrice;
                forest.BarkPrice = barkPrice;
                forest.LubPrice = lubPrice;
                forest.BirchBarkPrice = birchBarkPrice;
                forest.FirPawPrice = firPawPrice;
                forest.PinePawPrice = pinePawPrice;
                forest.SprucePawPrice = sprucePawPrice;
                forest.BrushwoodPrice = brushwoodPrice;
                forest.ForestFloorPrice = forestFloorPrice;
                forest.Money = forest.Stumps * stumpsPrice + forest.Bark * barkPrice + forest.Lub * lubPrice + forest.BirchBark * birchBarkPrice +
                    forest.FirPaw * firPawPrice + forest.PinePaw * pinePawPrice + forest.SprucePaw * sprucePawPrice + forest.Brushwood * brushwoodPrice +
                    forest.ForestFloor * forestFloorPrice;
            }

            forestResourceData.TotalMoney = forestResourceData.ModelList.Select(x => x.Money).Sum();

            var totalMoneyWithCoeff = forestResourceData.TotalMoney;
            totalMoneyWithCoeff *= MainCoefficient;
            forestResourceData.Coefficients.Add($"Коэффициент основной ({MainCoefficient}):", totalMoneyWithCoeff);
        }
        private async Task GetArticleInfo(ForestResourceData? forestResourceData)
        {
            if (forestResourceData is null)
            {
                throw new ArgumentNullException(nameof(forestResourceData));
            }

            forestResourceData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
    }
}