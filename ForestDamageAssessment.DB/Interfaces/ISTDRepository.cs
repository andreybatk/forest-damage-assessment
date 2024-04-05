using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.DB.Interfaces
{
    public interface ISTDRepository
    {
        Task<STD?> GetSTDAsync(double diameter);
    }
}