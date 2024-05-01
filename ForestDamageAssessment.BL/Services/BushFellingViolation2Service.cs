using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.DB.Interfaces;

namespace ForestDamageAssessment.BL.Services
{
    public class BushFellingViolation2Service : BushFellingViolationService, IExtendedViolationService<BushFellingViolation2Service, IBushViewModel>
    {
        public BushFellingViolation2Service(ITaxPriceRepository taxPriceRepository, IAssortmentRepository assortmentRepository, IArticleRepository articleRepository)
            : base(taxPriceRepository, assortmentRepository, articleRepository)
        {
        }

        protected override int ConiferousDiameter { get; } = 12;
        protected override int DeciduousDiameter { get; } = 16;
        protected override int ArticleID => 4;
    }
}