namespace ForestDamageAssessment.BL.Models
{
    public class ResinViewModel
    {
        /// <summary>
        /// Кол-во
        /// </summary>
        public double CountTon { get; set; }
        /// <summary>
        /// Порода
        /// </summary>
        public string Breed { get; set; }
        /// <summary>
        /// Штраф
        /// </summary>
        public double Money { get; set; }
        /// <summary>
        /// Ставка платы
        /// </summary>
        public double Price { get; set; }
    }
}