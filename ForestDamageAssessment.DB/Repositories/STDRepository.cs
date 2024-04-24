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
            int currentDiameter = Convert.ToInt32(diameter);

            return await _context.STDs.FirstOrDefaultAsync(x => x.ThicknessLevel == currentDiameter || x.ThicknessLevel == currentDiameter + 1 || x.ThicknessLevel == currentDiameter + 2 || x.ThicknessLevel == currentDiameter + 3 || x.ThicknessLevel == currentDiameter + 4);
        }
    }
}