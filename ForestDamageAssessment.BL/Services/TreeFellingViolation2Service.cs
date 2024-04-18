using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.DB.Interfaces;

namespace ForestDamageAssessment.BL.Services
{
    public class TreeFellingViolation2Service : TreeFellingViolationService, IExtendedViolationService<TreeFellingViolation2Service, ITreeViewModel>
    {
        public TreeFellingViolation2Service(IAssortmentRepository assortmentRepository, ITaxPriceRepository taxPriceRepository, IBreedDiameterModelRepository breedDiameterModelRepository, ISTDRepository sTDRepository)
            : base(assortmentRepository, taxPriceRepository, breedDiameterModelRepository, sTDRepository)
        {
        }

        protected override double MainCoefficient => 10D;
    }
}