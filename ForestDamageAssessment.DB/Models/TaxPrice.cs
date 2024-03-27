namespace ForestDamageAssessment.DB.Models
{
    public class TaxPrice
    {
        public int ID { get; set; }
        public string? TaxPriceCode { get; set; }
        public string? SubjectRF { get; set; }
        public string? Area { get; set; }
        public string? TaxPriceDesc { get; set; }
        public string? Breed { get; set; }
        public int? RankTax { get; set; }
        public string? TransportationDistance { get; set; }
        public string? PriceLarge { get; set; }
        public string? PriceAverage { get; set; }
        public string? PriceSmall { get; set; }
        public string? Firewood { get; set; }
    }
}