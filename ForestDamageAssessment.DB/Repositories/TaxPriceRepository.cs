using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace ForestDamageAssessment.DB.Repositories
{
    public class TaxPriceRepository : ITaxPriceRepository
    {
        private readonly ApplicationDbContext _context;

        public TaxPriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaxPrice?> GetTaxPriceAsync(string breed, string region)
        {
            return await _context.TaxPrices.FirstOrDefaultAsync(
                       x => x.SubjectRF == region && x.Breed == breed);
        }
    }
}