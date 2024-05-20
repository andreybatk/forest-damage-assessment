namespace ForestDamageAssessment.BL.Models
{
    public class ForestUseViewModel
    {
        /// <summary>
        /// Штраф
        /// </summary>
        public double Money { get; set; }
        /// <summary>
        /// Площадь
        /// </summary>
        public double Square { get; set; }
        /// <summary>
        /// Цена за нарушение
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Нарушение 1
        /// </summary>
        public bool IsViolation1 { get; set; }
        /// <summary>
        /// Нарушение 2
        /// </summary>
        public bool IsViolation2 { get; set; }
        /// <summary>
        /// Нарушение 3
        /// </summary>
        public bool IsViolation3 { get; set; }
        /// <summary>
        /// Цена за нарушение 1
        /// </summary>
        public double Violation1Price { get; set; }
        /// <summary>
        /// Цена за нарушение 2
        /// </summary>
        public double Violation2Price { get; set; }
        /// <summary>
        /// Цена за нарушение 3
        /// </summary>
        public double Violation3Price { get; set; }
    }
}