namespace ForestDamageAssessment.Models
{
    public class BreedStock
    {
        /// <summary>
        /// Ликвидный запас
        /// </summary>
        public double LiquidStock { get; set; }
        /// <summary>
        /// Корневой запас
        /// </summary>
        public double RootStock { get; set; }
        /// <summary>
        /// Крупная древесина
        /// </summary>
        public double SumLarge { get; set; }
        /// <summary>
        /// Средняя древесина
        /// </summary>
        public double SumAverage { get; set; }
        /// <summary>
        /// Мелкая древесина
        /// </summary>
        public double SumSmall { get; set; }
        /// <summary>
        /// Деловая дервесина
        /// </summary>
        public double SumBusiness { get; set; }
        /// <summary>
        /// Дровянная древесина
        /// </summary>
        public double SumFirewood { get; set; }
        /// <summary>
        /// Отходы
        /// </summary>
        public double SumWaste { get; set; }
    }
}
