using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IForestPollutionService<T>
    {
        Task<ForestPollutionData> CalculateAsync(string priceCleaning);
    }
}