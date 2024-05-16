using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IFoodResourceFellingService
    {
        Task<FoodResourceData> CalculateAsync(string[] treeSap, string[] wildFuits, string[] wildBerries, string[] wildMushrooms, string[] wildNuts,
            string[] seeds, string[] medicinalPlants, string region);
    }
}