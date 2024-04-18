using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IExtendedViolationService<T, TViewModel> : IViolationService<T, TViewModel>
    {
        Task<ForestArea<TViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestArea<TViewModel> forestArea);
    }
}