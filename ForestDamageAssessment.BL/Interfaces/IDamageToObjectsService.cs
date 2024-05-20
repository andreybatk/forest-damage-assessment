using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IDamageToObjectsService
    {
        Task<DamageToObjectsData> CalculateAsync(string price);
    }
}