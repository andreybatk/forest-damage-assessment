namespace ForestDamageAssessment.Models
{
    public class Violation1ViewModel
    {
        public Violation1ViewModel()
        {
            BreedStock = new BreedStock();
        }
        public string? Breed { get; set; }
        public int? ThicknessLevel { get; set; }
        public double? CalculatedDiameter { get; set; }
        public double Diameter { get; set; }
        public double H { get; set; }
        public double RankH { get; set; }
        public BreedStock BreedStock { get; set; }
    }
}
