using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace ForestDamageAssessment.DB.Repositories
{
    public class TaxPriceForestResourceRepository : ITaxPriceForestResourceRepository
    {
        private readonly ApplicationDbContext _context;

        public TaxPriceForestResourceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaxPriceForestResource?> GetTaxPriceAsync(string region)
        {
            return await _context.TaxPricesForestResource.FirstOrDefaultAsync(x => x.SubjectRF == region);
        }
    }
}