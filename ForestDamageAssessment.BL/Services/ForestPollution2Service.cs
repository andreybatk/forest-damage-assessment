using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.DB.Interfaces;

namespace ForestDamageAssessment.BL.Services
{
    public class ForestPollution2Service : ForestPollutionService, IForestPollutionService<ForestPollution2Service>
    {
        public ForestPollution2Service(IArticleRepository articleRepository) : base(articleRepository)
        {
        }

        protected override double MainCoefficient => 10D;
        protected override int ArticleID => 16;
    }
}