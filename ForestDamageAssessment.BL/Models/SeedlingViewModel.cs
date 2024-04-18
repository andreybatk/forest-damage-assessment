namespace ForestDamageAssessment.BL.Models
{
    public class SeedlingViewModel
    {
        /// <summary>
        /// Кол-во
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Порода
        /// </summary>
        public string Breed { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Штраф
        /// </summary>
        public double Money { get; set; }
    }
}
