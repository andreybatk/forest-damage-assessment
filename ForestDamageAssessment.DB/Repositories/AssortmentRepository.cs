using ForestDamageAssessment.DB.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ForestDamageAssessment.DB.Repositories
{
    public class AssortmentRepository : IAssortmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AssortmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IAssortment?> GetAssortmentAsync(string breed, string thicknessLevel, string rankH)
        {
            var currentBreed = breed.ToLower();
            IAssortment? assortment;


            if (currentBreed == "липа")
            {
                assortment = await _context.AssortmentsLinden.FirstOrDefaultAsync(
                            x => x.ThicknessLevel == thicknessLevel && x.RankH == rankH);
            }
            else if (currentBreed == "ива древовидная" || (currentBreed == "ольха черная") || (currentBreed == "осокорь"))
            {
                assortment = await _context.AssortmentsExtra.FirstOrDefaultAsync(
                    x => x.Breed == breed && x.ThicknessLevel == thicknessLevel && x.RankH == rankH);
            }
            else
            {
                assortment = await _context.Assortments.FirstOrDefaultAsync(
                    x => x.Breed == breed && x.ThicknessLevel == thicknessLevel && x.RankH == rankH);
            }

            return assortment;
        }
    }
}