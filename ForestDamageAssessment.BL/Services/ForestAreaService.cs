using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class ForestAreaService : IForestAreaService
    {
        public ForestArea<ITreeViewModel> CreateForestArea(string[] breed, string[] diameter, string[] h, string[] rankH,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var culture = new CultureInfo("en-us");
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var forestArea = new ForestArea<ITreeViewModel> { ForestData = forestData };
            forestArea.ModelList = new List<ITreeViewModel>();

            for (int i = 0; i < breed.Length; i++)
            {
                double.TryParse(diameter[i], culture, out double resultDiameter);
                double.TryParse(h[i], culture, out double resultH);
                double.TryParse(rankH[i], culture, out double resultRankH);

                var viewModel = new TreeViewModel { Breed = breed[i], Diameter = resultDiameter, H = resultH, RankH = resultRankH };
                forestArea.ModelList.Add(viewModel);
            }

            return forestArea;
        }
        public ForestArea<ITreeViewModel> CreateForestArea(string[] breed, string[] diameter,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var culture = new CultureInfo("en-us");
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var forestArea = new ForestArea<ITreeViewModel> { ForestData = forestData };
            forestArea.ModelList = new List<ITreeViewModel>();

            const double resultH = 130D;
            const double resultRankH = 1D;
            for (int i = 0; i < breed.Length; i++)
            {
                double.TryParse(diameter[i], culture, out double resultDiameter);

                var viewModel = new TreeViewModel { Breed = breed[i], Diameter = resultDiameter, H = resultH, RankH = resultRankH };
                forestArea.ModelList.Add(viewModel);
            }

            return forestArea;
        }
        public ForestArea<IBushViewModel> CreateForestArea(int[] count, string mainForestBreed, string[] breedBush, string[] bushType,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT, MainForestBreed = mainForestBreed };
            var forestArea = new ForestArea<IBushViewModel> { ForestData = forestData };
            forestArea.ModelList = new List<IBushViewModel>();

            for (int i = 0; i < count.Length; i++)
            {
                var viewModel = new BushViewModel { Breed = mainForestBreed, BushCount = count[i], BreedBush = breedBush[i], BushType = bushType[i] };
                forestArea.ModelList.Add(viewModel);
            }

            return forestArea;
        }
        public ForestArea<IBushViewModel> CreateForestArea(string mainForestBreed, string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT, MainForestBreed = mainForestBreed };
            return new ForestArea<IBushViewModel> { ForestData = forestData };
        }
    }
}