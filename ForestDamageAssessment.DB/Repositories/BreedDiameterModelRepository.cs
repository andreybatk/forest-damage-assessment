using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace ForestDamageAssessment.DB.Repositories
{
    public class BreedDiameterModelRepository : IBreedDiameterModelRepository
    {
        private readonly ApplicationDbContext _context;

        public BreedDiameterModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BreedDiameterModel?> GetBreedDiameterModelAsync(string breed)
        {
            return await _context.BreedDiameterModels.FirstOrDefaultAsync(x => x.Breed == breed);
        }
    }
}