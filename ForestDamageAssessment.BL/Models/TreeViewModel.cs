using ForestDamageAssessment.BL.Abstractions;
using ForestDamageAssessment.BL.Interfaces;

namespace ForestDamageAssessment.BL.Models
{
    public class TreeViewModel : ViolationViewModelBase, ITreeViewModel
    {
        public double CalculatedDiameter { get; set; }
        public double Diameter { get; set; }
        public double H { get; set; }
    }
}