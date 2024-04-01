using ForestDamageAssessment.Models;

namespace ForestDamageAssessment.Infrastructure
{
    public interface IForestAreaViewModelService
    {
        ForestAreaViewModel<ITreeViewModel> CreateForestAreaViewModel(string[] breed, string[] diameter, string[] h, string[] rankH,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT);
        ForestAreaViewModel<IBushViewModel> CreateForestAreaViewModel(int[] count, string[] breedBush, string[] bushType,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT);
    }
}