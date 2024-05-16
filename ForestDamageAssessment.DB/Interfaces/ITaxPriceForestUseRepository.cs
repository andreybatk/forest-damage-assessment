using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.DB.Interfaces
{
    public interface ITaxPriceForestUseRepository
    {
        Task<TaxPriceForestUse?> GetTaxPriceAsync(string region);
    }
}