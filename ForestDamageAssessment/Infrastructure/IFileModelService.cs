using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.Infrastructure
{
    public interface IFileModelService
    {
        Task<FileModel> CreateFileModelAsync(IFormFile uploadedFile);
    }
}