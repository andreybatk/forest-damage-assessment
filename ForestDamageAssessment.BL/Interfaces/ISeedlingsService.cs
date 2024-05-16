using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface ISeedlingsService
    {
        Task<SeedlingData> CalculateAsync(int[] count, string[] breed, string[] price);
    }
}