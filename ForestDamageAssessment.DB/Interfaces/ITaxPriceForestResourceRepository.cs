using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.DB.Interfaces
{
    public interface ITaxPriceForestResourceRepository
    {
        Task<TaxPriceForestResource?> GetTaxPriceAsync(string region);
    }
}