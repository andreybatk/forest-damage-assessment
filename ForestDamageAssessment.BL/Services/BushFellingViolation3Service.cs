using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.DB.Interfaces;

namespace ForestDamageAssessment.BL.Services
{
    public class BushFellingViolation3Service : BushFellingViolationService, IExtendedViolationService<BushFellingViolation3Service, IBushViewModel>
    {
        public BushFellingViolation3Service(ITaxPriceRepository taxPriceRepository, IAssortmentRepository assortmentRepository, IArticleRepository articleRepository)
            : base(taxPriceRepository, assortmentRepository, articleRepository)
        {
        }

        protected override int ConiferousDiameter { get; } = 20;
        protected override int DeciduousDiameter { get; } = 20;
        protected override int ArticleID => 19;
    }
}