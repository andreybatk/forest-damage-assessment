using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.BL.Models
{
    public class RemovalOfAnthillsData
    {
        public RemovalOfAnthillsData()
        {
            Coefficients = new Dictionary<string, double>();
        }

        /// <summary>
        /// Регион
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Модели
        /// </summary>
        public List<AnthillViewModel>? ModelList;
        /// <summary>
        /// Коэффициенты и размер ущерба
        /// </summary>
        public Dictionary<string, double> Coefficients { get; set; }
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
