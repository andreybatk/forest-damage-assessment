using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.DB.Interfaces
{
    public interface ITaxPriceFoodResourceRepository
    {
        Task<TaxPriceFoodResource?> GetTaxPriceAsync(string region);
    }
}