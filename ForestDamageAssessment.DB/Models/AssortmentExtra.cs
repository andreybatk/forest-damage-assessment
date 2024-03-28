using ForestDamageAssessment.DB.Infrastructure;

namespace ForestDamageAssessment.DB.Models
{
    public class AssortmentExtra : IAssortmentTable
    {
        public int ID { get; set; }
        public string? Breed { get; set; }
        public string? RankH { get; set; }
        public string? ThicknessLevel { get; set; }
        public string? H { get; set; }
        public string? VInBark { get; set; }
        public string? UnitOfMeasure { get; set; }
        public string? LargeTotal { get; set; }
        public string? Average1Total { get; set; }
        public string? Average2Total { get; set; }
        public string? SmallTotal { get; set; }
        public string? AllBusiness { get; set; }
        public string? PlywoodLog { get; set; }
        public string? Sawlog { get; set; }
        public string? CommodityRidge { get; set; }
        public string? Stroyles { get; set; }
        public string? Podtovarnik { get; set; }
        public string? TechnologicalRawMaterials { get; set; }
        public string? FirewoodFuel { get; set; }
        public string? Waste { get; set; }
        public string? TechnologicalRawMaterialsFirewood { get; set; }
        public string? FirewoodFuelFirewood { get; set; }
        public string? WasteFirewood { get; set; }
        public string? Bark { get; set; }
    }
}