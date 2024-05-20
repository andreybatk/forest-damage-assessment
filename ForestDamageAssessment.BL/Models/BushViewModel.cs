using ForestDamageAssessment.BL.Abstractions;
using ForestDamageAssessment.BL.Interfaces;

namespace ForestDamageAssessment.BL.Models
{
    public class BushViewModel : ViolationViewModelBase, IBushViewModel
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