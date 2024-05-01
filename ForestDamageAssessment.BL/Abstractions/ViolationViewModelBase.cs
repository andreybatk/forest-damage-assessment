using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Abstractions
{
    public abstract class ViolationViewModelBase : IViolationViewModel
    {
        public ViolationViewModelBase()
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