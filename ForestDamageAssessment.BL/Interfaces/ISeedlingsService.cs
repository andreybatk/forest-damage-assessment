using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface ISeedlingsService
    {
        Task<SeedlingData> Calculate(int[] count, string[] breed, string[] price);
    }
}