using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace ForestDamageAssessment.DB.Repositories
{
    public class TaxPriceResinRepository : ITaxPriceResinRepository
    {
        private readonly ApplicationDbContext _context;

        public TaxPriceResinRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaxPriceResin?> GetTaxPriceResinAsync(string breed, string region)
        {
            return await _context.TaxPricesResin.FirstOrDefaultAsync(
                       x => x.SubjectRF == region && x.Breed == breed);
        }
    }
}