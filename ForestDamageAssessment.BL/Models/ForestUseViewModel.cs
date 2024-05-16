namespace ForestDamageAssessment.BL.Models
{
    public class ForestUseViewModel
    {
        /// <summary>
        /// Штраф
        /// </summary>
        public double Money { get; set; }
        public double Square { get; set; }
        public double Price { get; set; }
        public bool IsViolation1 { get; set; }
        public bool IsViolation2 { get; set; }
        public bool IsViolation3 { get; set; }
        public double Violation1Price { get; set; }
        public double Violation2Price { get; set; }
        public double Violation3Price { get; set; }
    }
}