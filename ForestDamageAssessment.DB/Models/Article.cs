namespace ForestDamageAssessment.DB.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Punish { get; set; }
        public string? Description { get; set; }
        public int? ArticleNumber { get; set; }
        public int? AppendixNumber { get; set; }
    }
}