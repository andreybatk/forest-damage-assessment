namespace ForestDamageAssessment.Data
{
    public class ForestArea
    {
        /// <summary>
        /// Регион
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// Год
        /// </summary>
        public string? Year { get; set; }
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
    }
}