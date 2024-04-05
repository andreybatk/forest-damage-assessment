using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IViolationService<T, TViewModel>
    {
        Task<ForestAreaModel<TViewModel>> CalculateAsync(ForestAreaModel<TViewModel> forestArea);
        Task<ForestAreaModel<TViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestAreaModel<TViewModel> forestArea);
    }
}