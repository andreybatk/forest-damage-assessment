using ForestDamageAssessment.DB;
using ForestDamageAssessment.Infrastructure;

namespace ForestDamageAssessment.Data
{
    public class BushFellingViolation2Calculate : BushFellingViolationCalculate, IViolationCalculate<BushFellingViolation2Calculate, IBushViewModel>
    {
        public BushFellingViolation2Calculate(ApplicationDbContext context) : base(context)
        {
        }

        protected override int ConiferousDiameter { get; } = 12;
        protected override int DeciduousDiameter { get; } = 16;
    }
}