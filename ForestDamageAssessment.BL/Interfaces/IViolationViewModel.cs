using ForestDamageAssessment.BL.Models;

namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IViolationViewModel
    {
        /// <summary>
        /// Порода
        /// </summary>
        public string? Breed { get; set; }
        /// <summary>
        /// Ступень толищны (диаметр)
        /// </summary>
        public int? ThicknessLevel { get; set; }
        /// <summary>
        /// Разряд высот
        /// </summary>
        public double RankH { get; set; }
        /// <summary>
        /// Запас дерева
        /// </summary>
        public BreedStock Stock { get; set; }
        /// <summary>
        /// Штраф
        /// </summary>
		public MoneyPunishment Money { get; set; }
    }
}