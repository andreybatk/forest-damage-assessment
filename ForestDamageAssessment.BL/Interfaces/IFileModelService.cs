using ForestDamageAssessment.DB.Models;
using Microsoft.AspNetCore.Http;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IFileModelService
    {
        Task<FileModel> CreateFileModelAsync(IFormFile uploadedFile);
    }
}