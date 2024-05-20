using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IRemovalOfSignsService
    {
        Task<RemovalOfSignsData> CalculateAsync(string price);
    }
}