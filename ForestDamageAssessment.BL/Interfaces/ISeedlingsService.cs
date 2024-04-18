using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface ISeedlingsService
    {
        SeedlingData Calculate(int[] count, string[] breed, string[] price);
    }
}