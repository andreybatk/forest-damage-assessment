using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.DB.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article?> GetArticleAsync(int id);
    }
}