using ForestDamageAssessment.DB.Interfaces;

namespace ForestDamageAssessment.DB.Models
{
    public class AssortmentLinden : IAssortment
    {
        public int ID { get; set; }
        public string? Breed { get; set; }
        public string? RankH { get; set; }
        public string? ThicknessLevel { get; set; }
        public string? H { get; set; }
        public string? VInBark { get; set; }
        public string? Large1 { get; set; }
        public string? Large2 { get; set; }
        public string? Large3 { get; set; }
        public string? LargeTotal { get; set; }
        public string? Average1_1 { get; set; }
        public string? Average1_2 { get; set; }
        public string? Average1_3 { get; set; }
        public string? Average1Total { get; set; }
        public string? Average2_1 { get; set; }
        public string? Average2_2 { get; set; }
        public string? Average2_3 { get; set; }
        public string? Average2Total { get; set; }
        public string? Small1 { get; set; }
        public string? Small2 { get; set; }
        public string? Small3 { get; set; }
        public string? SmallTotal { get; set; }
        public string? AllBusiness { get; set; }
        public string? TechnologicalRawMaterials { get; set; }
        public string? FirewoodFuel { get; set; }
        public string? Waste { get; set; }
        public string? Bark { get; set; }
        public string? Total { get; set; }
    }
}