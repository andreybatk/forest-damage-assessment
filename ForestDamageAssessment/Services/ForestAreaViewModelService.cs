using ForestDamageAssessment.Data;
using ForestDamageAssessment.Infrastructure;
using ForestDamageAssessment.Models;
using System.Globalization;

namespace ForestDamageAssessment.Services
{
    public class ForestAreaViewModelService : IForestAreaViewModelService
    {
        public ForestAreaViewModel<ITreeViewModel> CreateForestAreaViewModel(string[] breed, string[] diameter, string[] h, string[] rankH,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var forestArea = new ForestAreaViewModel<ITreeViewModel> { ForestData = forestData };
            var culture = new CultureInfo("en-us");
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

        public ForestAreaViewModel<IBushViewModel> CreateForestAreaViewModel(int[] count, string[] breedBush, string[] bushType,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var forestArea = new ForestAreaViewModel<IBushViewModel> { ForestData = forestData };
            forestArea.ModelList = new List<IBushViewModel>();

            for (int i = 0; i < count.Length; i++)
            {
                var viewModel = new BushViewModel { BushCount = count[i], BreedBush = breedBush[i], BushType = bushType[i] };
                forestArea.ModelList.Add(viewModel);
            }

            return forestArea;
        }
    }
}