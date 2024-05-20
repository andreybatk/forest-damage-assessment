namespace ForestDamageAssessment.BL.Models
{
    public class AnthillViewModel
    {
        /// <summary>
        /// Штраф
        /// </summary>
        public double Money { get; set; }
        /// <summary>
        /// Диаметр муравейника
        /// </summary>
        public double Diameter { get; set; }
        /// <summary>
        /// Коэффициент нарушения
        /// </summary>
        public double Coeff { get; set; }
        /// <summary>
        /// Основная лесообразующая порода
        /// </summary>
        public string MainForestBreed { get; set; }
        /// <summary>
        /// Ставка платы
        /// </summary>
        public double MainForestBreedPrice { get; set; }
    }
}