using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace ForestDamageAssessment.DB.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Article?> GetArticleAsync(int id)
        {
            return await _context.Articles.FirstOrDefaultAsync(
                       x => x.ID == id);
        }
    }
}
