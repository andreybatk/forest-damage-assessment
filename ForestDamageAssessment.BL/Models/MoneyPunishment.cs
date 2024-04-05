namespace ForestDamageAssessment.BL.Models
{
    public class MoneyPunishment
    {
        /// <summary>
        /// Штраф за деловую древесину
        /// </summary>
        public double Business { get; set; }
        /// <summary>
        /// Штраф за дровяную древесину
        /// </summary>
        public double Firewood { get; set; }
        /// <summary>
        /// Общий штраф за деловую и дровяную древесину
        /// </summary>
        public double BusinessAndFirewood { get; set; }
        /// <summary>
        /// Ставка платы за деловую древесину (средняя)
        /// </summary>
        public double TaxPriceBusiness { get; set; }
        /// <summary>
        /// Ставка платы за дровяную древесину (средняя)
        /// </summary>
        public double TaxPriceFirewood { get; set; }
    }
}