using ForestDamageAssessment.Infrastructure;

namespace ForestDamageAssessment.Models
{
    public class TreeViewModel : ViolationViewModel, ITreeViewModel
    {
        public double CalculatedDiameter { get; set; }
        public double Diameter { get; set; }
        public double H { get; set; }
    }
}