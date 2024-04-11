using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IForestAreaService
    {
        ForestArea<ITreeViewModel> CreateForestArea(string[] breed, string[] diameter, string[] h, string[] rankH,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT);
        ForestArea<IBushViewModel> CreateForestArea(int[] count, string[] breedBush, string[] bushType,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT);
    }
}