using ForestDamageAssessment.Infrastructure;

namespace ForestDamageAssessment.Models
{
    public class BushViewModel : ViolationViewModel, IBushViewModel
    {
        public int? BushCount { get; set; }
        public string? BreedBush { get; set; }
        public string? BushType { get; set; }
    }
}