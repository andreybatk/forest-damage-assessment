using ForestDamageAssessment.BL.Abstractions;
using ForestDamageAssessment.BL.Interfaces;

namespace ForestDamageAssessment.BL.Models
{
    public class TreeViewModel : ViolationViewModelBase, ITreeViewModel
    {
        /// <summary>
        /// Расчитанный диаметр на 1.3м
        /// </summary>
        public double CalculatedDiameter { get; set; }
        /// <summary>
        /// Диаметр пня
        /// </summary>
        public double Diameter { get; set; }
        /// <summary>
        /// Высота пня
        /// </summary>
        public double H { get; set; }
    }
}