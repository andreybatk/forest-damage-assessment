using ForestDamageAssessment.Data;
using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.Infrastructure
{
    public interface IViolationCalculate<T, TViewModel>
    {
        Task<List<TViewModel>> CalculateAsync(List<TViewModel> modelList, ForestArea forestArea);
        Task<List<TViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestArea forestArea);
        Task<FileModel> GetFileModel(IFormFile uploadedFile);
        ForestArea GetForestArea(string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT);
    }
}