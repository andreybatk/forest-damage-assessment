using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace ForestDamageAssessment.DB.Repositories
{
    public class STDRepository : ISTDRepository
    {
        private readonly ApplicationDbContext _context;

        public STDRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<STD?> GetSTDAsync(double diameter)
        {
           return await _context.STDs.FirstOrDefaultAsync(x => x.ThicknessLevel == diameter || x.ThicknessLevel == diameter + 1 || x.ThicknessLevel == diameter + 2 || x.ThicknessLevel == diameter + 3 || x.ThicknessLevel == diameter + 4);
        }
    }
}