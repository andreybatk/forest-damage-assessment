﻿namespace ForestDamageAssessment.DB.Interfaces
{
    public interface IAssortment
    {
        /// <summary>
        /// Объем ствола в коре
        /// </summary>
        string VInBark { get; set; }
        /// <summary>
        /// Крупная итого
        /// </summary>
        string LargeTotal { get; set; }
        /// <summary>
        /// Средняя-1 итого
        /// </summary>
        string Average1Total { get; set; }
        /// <summary>
        /// Средняя-2 итого
        /// </summary>
        string Average2Total { get; set; }
        /// <summary>
        /// Мелкая итого
        /// </summary>
        string SmallTotal { get; set; }
        /// <summary>
        /// Всего деловой
        /// </summary>
        string AllBusiness { get; set; }
        /// <summary>
        /// Технологическое сырье
        /// </summary>
        string TechnologicalRawMaterials { get; set; }
        /// <summary>
        /// Дрова топливные
        /// </summary>
        string FirewoodFuel { get; set; }
        /// <summary>
        /// Отходы
        /// </summary>
        string Waste { get; set; }
    }
}