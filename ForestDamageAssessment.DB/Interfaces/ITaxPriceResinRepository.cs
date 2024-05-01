using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.DB.Interfaces
{
    public interface ITaxPriceResinRepository
    {
        Task<TaxPriceResin?> GetTaxPriceResinAsync(string breed, string region);
    }
}