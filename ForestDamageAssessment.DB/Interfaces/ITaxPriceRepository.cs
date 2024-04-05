using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.DB.Interfaces
{
    public interface ITaxPriceRepository
    {
        Task<TaxPrice?> GetTaxPriceAsync(string breed, string region);
    }
}