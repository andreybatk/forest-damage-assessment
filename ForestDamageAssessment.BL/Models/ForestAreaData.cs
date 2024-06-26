﻿using ForestDamageAssessment.DB.Models;

namespace ForestDamageAssessment.BL.Models
{
    public class ForestAreaData
    {
        public ForestAreaData()
        {
            Coefficients = new Dictionary<string, double>();
        }

        /// <summary>
        /// Регион
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Год
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// Защитные леса
        /// </summary>
        public bool IsProtectiveForests { get; set; }
        /// <summary>
        /// Особо защитные участки леса
        /// </summary>
        public bool IsOZU { get; set; }
        /// <summary>
        /// ООПТ
        /// </summary>
        public bool IsOOPT { get; set; }
        /// <summary>
        /// Общий штраф за всю лесосеку с учетом всех коэффициентов
        /// </summary>
        public double TotalMoney { get; set; }
        /// <summary>
        /// Общий штраф за деловую древесину на лесном участке
        /// </summary>
        public double TotalBusinessMoney { get; set; }
        /// <summary>
        /// Общий штраф за крупную древесину на лесном участке
        /// </summary>
        public double TotalLargeMoney { get; set; }
        /// <summary>
        /// Общий штраф за среднюю древесину на лесном участке
        /// </summary>
        public double TotalAverageMoney { get; set; }
        /// <summary>
        /// Общий штраф за мелкую древесину на лесном участке
        /// </summary>
        public double TotalSmallMoney { get; set; }
        /// <summary>
        /// Общий штраф за дровяную древесину на лесном участке
        /// </summary>
        public double TotalFirewoodMoney { get; set; }
        /// <summary>
        /// Общий штраф за деловую и дровяную древесину на лесном участке
        /// </summary>
        public double TotalBusinessAndFirewoodMoney { get; set; }
        /// <summary>
        /// Общий корневой запас на лесном участке
        /// </summary>
        public double TotalRootStock { get; set; }
        /// <summary>
        /// Общий ликвидный запас на лесном участке
        /// </summary>
        public double TotalLiquidStock { get; set; }
        /// <summary>
        /// Коэффициенты и размер ущерба
        /// </summary>
        public Dictionary<string, double> Coefficients { get; set; }
        /// <summary>
        /// Основная лесообразующая порода
        /// </summary>
        public string? MainForestBreed { get; set; }
        /// <summary>
        /// Вид нарушения, приложение
        /// </summary>
        public Article? ViolationArticle { get; set; }
    }
}