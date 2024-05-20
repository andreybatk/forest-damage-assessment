using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IPlacementOfObjectsService
    {
        Task<PlacementOfObjectsData> CalculateAsync(string square, string price, string priceCleaning);
    }
}