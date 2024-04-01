using ForestDamageAssessment.DB;
using ForestDamageAssessment.Infrastructure;

namespace ForestDamageAssessment.Data
{
    public class TreeFellingViolation2Calculate : TreeFellingViolationCalculate, IViolationCalculate<TreeFellingViolation2Calculate, ITreeViewModel>
    {
        public TreeFellingViolation2Calculate(ApplicationDbContext context) : base(context)
        {
        }

        protected override double MainCoefficient => 10D;
    }
}