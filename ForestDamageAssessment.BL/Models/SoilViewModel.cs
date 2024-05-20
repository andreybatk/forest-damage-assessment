namespace ForestDamageAssessment.BL.Models
{
    public class SoilViewModel
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
        /// Основная лесообразующая порода
        /// </summary>
        public string MainForestBreed { get; set; }
        /// <summary>
        /// Ставка платы
        /// </summary>
        public double MainForestBreedPrice { get; set; }
        /// <summary>
        /// Кол-во транспортных средств
        /// </summary>
        public int VehicleCount { get; set; }
    }
}