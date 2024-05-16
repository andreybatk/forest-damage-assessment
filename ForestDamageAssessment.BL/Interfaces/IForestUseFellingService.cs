using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IForestUseFellingService
    {
        Task<ForestUseData> CalculateAsync(string[] square, string[] price, bool isViolation1, bool isViolation2, bool isViolation3, string region);
    }
}