namespace ForestDamageAssessment.BL.Models
{
    public class ObjectViewModel
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
        /// Цена за очистку территории
        /// </summary>
        public double PriceCleaning { get; set; }
    }
}