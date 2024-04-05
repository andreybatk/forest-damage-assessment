namespace ForestDamageAssessment.BL.Models
{
    public class ForestAreaModel<T>
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