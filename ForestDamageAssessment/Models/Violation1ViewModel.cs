namespace ForestDamageAssessment.Models
{
    public class Violation1ViewModel
    {
        public string? Breed { get; set; }
        public double Diameter { get; set; }
        public double H { get; set; }
        public double RankH { get; set; }
        public double? CalculatedDiameter { get; set; }
        public int? ThicknessLevel { get; set; }
    }
}
