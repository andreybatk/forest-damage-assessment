using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IPlantationFellingService
    {
        Task<PlantationData> Calculate(string[] square, string[] price, int[] coeff);
    }
}