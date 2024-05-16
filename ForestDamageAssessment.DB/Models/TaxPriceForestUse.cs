namespace ForestDamageAssessment.DB.Models
{
    public class TaxPriceForestUse
    {
        public int ID { get; set; }
        public string? SubjectRF { get; set; }
        public string? Violation1Price { get; set; }
        public string? Violation2Price { get; set; }
        public string? Violation3Price { get; set; }
    }
}