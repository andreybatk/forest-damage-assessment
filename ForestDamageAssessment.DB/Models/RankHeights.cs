namespace ForestDamageAssessment.DB.Models
{
    public class RankHeight
    {
        public int ID { get; set; }
        public string? Breed { get; set; }
        public string? ThicknessLevel { get; set; }
        public string? MinH { get; set; }
        public string? MaxH { get; set; }
        public int? RankH { get; set; }
    }
}