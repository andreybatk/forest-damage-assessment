namespace ForestDamageAssessment.Models
{
    public class Violation1ViewModel
    {
        public Violation1ViewModel()
        {
            Stock = new BreedStock();
            Money = new MoneyPunishment();
            Area = new ForestArea();
		}
        /// <summary>
        /// Порода
        /// </summary>
        public string Breed { get; set; }
        /// <summary>
        /// Ступень толищны (диаметр)
        /// </summary>
        public int? ThicknessLevel { get; set; }
        /// <summary>
        /// Диаметр на 1.3м
        /// </summary>
        public double CalculatedDiameter { get; set; }
        /// <summary>
        /// Диаметр пня
        /// </summary>
        public double Diameter { get; set; }
        /// <summary>
        /// Высота пня
        /// </summary>
        public double H { get; set; }
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
        /// <summary>
        /// Лесной участок
        /// </summary>
	    public ForestArea Area { get; set; }
        
	}
}
