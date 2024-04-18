using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.DB.Interfaces;

namespace ForestDamageAssessment.BL.Services
{
    public class BushFellingViolation2Service : BushFellingViolationService, IExtendedViolationService<BushFellingViolation2Service, IBushViewModel>
    {
        public BushFellingViolation2Service(IAssortmentRepository assortmentRepository, ITaxPriceRepository taxPriceRepository)
            : base(assortmentRepository, taxPriceRepository)
        {
        }

        protected override int ConiferousDiameter { get; } = 12;
        protected override int DeciduousDiameter { get; } = 16;
    }
}