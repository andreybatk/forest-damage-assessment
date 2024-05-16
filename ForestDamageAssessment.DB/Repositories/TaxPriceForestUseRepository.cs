using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace ForestDamageAssessment.DB.Repositories
{
    public class TaxPriceForestUseRepository : ITaxPriceForestUseRepository
    {
        private readonly ApplicationDbContext _context;

        public TaxPriceForestUseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaxPriceForestUse?> GetTaxPriceAsync(string region)
        {
            return await _context.TaxPricesForestUse.FirstOrDefaultAsync(x => x.SubjectRF == region);
        }
    }
}