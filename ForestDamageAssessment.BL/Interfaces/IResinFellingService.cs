using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IResinFellingService
    {
        Task<ResinData> Calculate(string[] countTon, string[] breed, string region);
    }
}