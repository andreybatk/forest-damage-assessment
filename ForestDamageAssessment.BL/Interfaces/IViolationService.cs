using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IViolationService<T, TViewModel>
    {
        Task<ForestArea<TViewModel>> CalculateAsync(ForestArea<TViewModel> forestArea);
        Task<ForestArea<TViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestArea<TViewModel> forestArea);
    }
}