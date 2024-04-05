namespace ForestDamageAssessment.BL.Interfaces
{
    public interface ITreeViewModel : IViolationViewModel
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