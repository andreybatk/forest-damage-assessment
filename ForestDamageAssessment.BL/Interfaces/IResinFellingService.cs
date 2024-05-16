using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IResinFellingService
    {
        Task<ResinData> CalculateAsync(string[] countTon, string[] breed, string region);
    }
}