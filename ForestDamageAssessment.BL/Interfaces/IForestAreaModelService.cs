using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IForestAreaModelService
    {
        ForestAreaModel<ITreeViewModel> CreateForestAreaViewModel(string[] breed, string[] diameter, string[] h, string[] rankH,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT);
        ForestAreaModel<IBushViewModel> CreateForestAreaViewModel(int[] count, string[] breedBush, string[] bushType,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT);
    }
}