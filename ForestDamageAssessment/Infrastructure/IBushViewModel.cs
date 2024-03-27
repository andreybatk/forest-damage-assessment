namespace ForestDamageAssessment.Infrastructure
{
    public interface IBushViewModel : IViolationViewModel
    {
        /// <summary>
        /// Кол-во кустарников или лиан
        /// </summary>
        public int? BushCount { get; set; }
        /// <summary>
        /// Порода кустарника или лиан
        /// </summary>
        public string? BreedBush { get; set; }
        /// <summary>
        /// Тип кустарника
        /// </summary>
        public string? BushType { get; set; }
    }
}