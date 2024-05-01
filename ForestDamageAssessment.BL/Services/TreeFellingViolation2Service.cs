using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.DB.Interfaces;

namespace ForestDamageAssessment.BL.Services
{
    public class TreeFellingViolation2Service : TreeFellingViolationService, IExtendedViolationService<TreeFellingViolation2Service, ITreeViewModel>
    {
        public TreeFellingViolation2Service(IAssortmentRepository assortmentRepository, ITaxPriceRepository taxPriceRepository, IBreedDiameterModelRepository breedDiameterModelRepository, ISTDRepository sTDRepository, IArticleRepository articleRepository)
            : base(assortmentRepository, taxPriceRepository, breedDiameterModelRepository, sTDRepository, articleRepository)
        {
        }

        protected override double MainCoefficient => 10D;
        protected override int ArticleID => 3;
    }
}