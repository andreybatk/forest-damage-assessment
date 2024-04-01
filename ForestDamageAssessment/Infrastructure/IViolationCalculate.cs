using ForestDamageAssessment.DB.Models;
using ForestDamageAssessment.Models;

namespace ForestDamageAssessment.Infrastructure
{
    public interface IViolationCalculate<T, TViewModel>
    {
        Task<ForestAreaViewModel<TViewModel>> CalculateAsync(ForestAreaViewModel<TViewModel> forestArea);
        Task<ForestAreaViewModel<TViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestAreaViewModel<TViewModel> forestArea);
    }
}