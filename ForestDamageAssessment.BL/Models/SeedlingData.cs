namespace ForestDamageAssessment.BL.Models
{
    public class SeedlingData
    {
        public SeedlingData()
        {
            Coefficients = new Dictionary<string, double>();
        }

        public List<SeedlingViewModel>? ModelList;
        public Dictionary<string, double> Coefficients { get; set; }
        public double TotalMoney { get; set; }
    }
}