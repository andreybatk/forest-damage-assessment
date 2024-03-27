using ForestDamageAssessment.Data;
using ForestDamageAssessment.Infrastructure;

namespace ForestDamageAssessment.Models
{
    public abstract class ViolationViewModel : IViolationViewModel
    {
        public ViolationViewModel()
        {
            Stock = new BreedStock();
            Money = new MoneyPunishment();
        }

        public string? Breed { get; set; }
        public int? ThicknessLevel { get; set; }
        public double RankH { get; set; }
        public BreedStock Stock { get; set; }
        public MoneyPunishment Money { get; set; }
    }
}