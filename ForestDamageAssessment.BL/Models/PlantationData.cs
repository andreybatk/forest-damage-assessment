using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.BL.Models
{
    public class PlantationData
    {
        /// <summary>
        /// Модели
        /// </summary>
        public List<PlantationViewModel>? ModelList;
        /// <summary>
        /// Общий штраф
        /// </summary>
        public double TotalMoney { get; set; }
        /// <summary>
        /// Вид нарушения, приложение
        /// </summary>
        public Article? ViolationArticle { get; set; }
    }
}
