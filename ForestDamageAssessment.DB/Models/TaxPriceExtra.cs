namespace ForestDamageAssessment.DB.Models
{
    public class TaxPriceExtra
    {
        public int ID { get; set; }
        public string? SubjectRF { get; set; }
        public string? TreeCessationOfGrowth { get; set; }
        public string? TreeWithoutCessationOfGrowth { get; set; }
        public string? BushCessationOfGrowth { get; set; }
        public string? BushWithoutCessationOfGrowth { get; set; }
    }
}
