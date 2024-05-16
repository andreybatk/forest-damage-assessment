using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.DB.Interfaces
{
    public interface ITaxPriceResinRepository
    {
        Task<TaxPriceResin?> GetTaxPriceAsync(string breed, string region);
    }
}