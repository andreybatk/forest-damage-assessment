namespace ForestDamageAssessment.BL.Models
{
    public class PlantationViewModel
    {
        /// <summary>
        /// Коэффициент нарушения
        /// </summary>
        public double Coeff { get; set; }
        /// <summary>
        /// Площадь участка (га)
        /// </summary>
        public double Square { get; set; }
        /// <summary>
        /// Цена за гектар
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Штраф
        /// </summary>
        public double Money { get; set; }
    }
}
