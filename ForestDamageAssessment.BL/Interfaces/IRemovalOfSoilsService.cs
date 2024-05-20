using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IRemovalOfSoilsService
    {
        Task<RemovalOfSoilsData> CalculateAsync(string square, int vehicleCount, string mainForestBreed, string region);
    }
}