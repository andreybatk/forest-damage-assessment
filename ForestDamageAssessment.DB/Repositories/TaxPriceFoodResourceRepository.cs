using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace ForestDamageAssessment.DB.Repositories
{
    public class TaxPriceFoodResourceRepository : ITaxPriceFoodResourceRepository
    {
        private readonly ApplicationDbContext _context;

        public TaxPriceFoodResourceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaxPriceFoodResource?> GetTaxPriceAsync(string region)
        {
            return await _context.TaxPricesFoodResource.FirstOrDefaultAsync(x => x.SubjectRF == region);
        }
    }
}