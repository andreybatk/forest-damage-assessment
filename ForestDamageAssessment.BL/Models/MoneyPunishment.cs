namespace ForestDamageAssessment.BL.Models
{
    public class MoneyPunishment
    {
        /// <summary>
        /// Штраф за деловую древесину
        /// </summary>
        public double Business { get; set; }
        /// <summary>
        /// Штраф за крупную древесину
        /// </summary>
        public double Large { get; set; }
        /// <summary>
        /// Штраф за среднюю древесину
        /// </summary>
        public double Average { get; set; }
        /// <summary>
        /// Штраф за мелкую древесину
        /// </summary>
        public double Small { get; set; }
        /// <summary>
        /// Штраф за дровяную древесину
        /// </summary>
        public double Firewood { get; set; }
        /// <summary>
        /// Общий штраф за деловую и дровяную древесину
        /// </summary>
        public double BusinessAndFirewood { get; set; }
        /// <summary>
        /// Ставка платы за среднюю древесину (средняя)
        /// </summary>
        public double TaxPriceAverage { get; set; }
        /// <summary>
        /// Ставка платы за среднюю древесину (средняя)
        /// </summary>
        public double TaxPriceLarge { get; set; }
        /// <summary>
        /// Ставка платы за мекую древесину (средняя)
        /// </summary>
        public double TaxPriceSmall { get; set; }
        /// <summary>
        /// Ставка платы за дровяную древесину (средняя)
        /// </summary>
        public double TaxPriceFirewood { get; set; }
    }
}