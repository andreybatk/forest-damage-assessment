using ForestDamageAssessment.Data;

namespace ForestDamageAssessment.Models
{
    public class ForestAreaViewModel<T>
    {
        /// <summary>
        /// Общие данные о лесном участке
        /// </summary>
        public ForestAreaData? ForestData { get; set; }
        /// <summary>
        /// Модели
        /// </summary>
        public List<T>? ModelList;
    }
}