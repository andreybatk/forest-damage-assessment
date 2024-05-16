using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IForestResourceFellingService
    {
        Task<ForestResourceData> CalculateAsync(string[] stumps, string[] bark, string[] lub, string[] birchBark, string[] firPaw,
            string[] pinePaw, string[] sprucePaw, string[] brushwood, string[] forestFloor, string region);
    }
}