using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IRemovalOfAnthillsService
    {
        Task<RemovalOfAnthillsData> CalculateAsync(string[] diameter, string mainForestBreed, string region);
    }
}