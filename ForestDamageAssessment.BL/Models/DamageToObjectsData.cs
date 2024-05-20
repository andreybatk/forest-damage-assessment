using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.BL.Models
{
    public class DamageToObjectsData
    {
        public DamageToObjectsData()
        {
            Coefficients = new Dictionary<string, double>();
        }

        /// <summary>
        /// Модель
        /// </summary>
        public DamageToObjectsViewModel? Model;
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