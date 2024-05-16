using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IPlantationFellingService
    {
        Task<PlantationData> CalculateAsync(string[] square, string[] price, int[] coeff);
    }
}