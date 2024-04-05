using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.DB.Interfaces
{
    public interface IBreedDiameterModelRepository
    {
        Task<BreedDiameterModel?> GetBreedDiameterModelAsync(string breed);
    }
}