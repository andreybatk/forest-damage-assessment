namespace ForestDamageAssessment.BL.Models
{
    public class ForestResourceViewModel
    {
        /// <summary>
        /// Штраф
        /// </summary>
        public double Money { get; set; }
        /// <summary>
        /// Пни
        /// </summary>
        public double Stumps { get; set; }
        /// <summary>
        /// Кора
        /// </summary>
        public double Bark { get; set; }
        /// <summary>
        /// Луб
        /// </summary>
        public double Lub { get; set; }
        /// <summary>
        /// Береста
        /// </summary>
        public double BirchBark { get; set; }
        /// <summary>
        /// Пихтовая лапа
        /// </summary>
        public double FirPaw { get; set; }
        /// <summary>
        /// Сосновая лапа
        /// </summary>
        public double PinePaw { get; set; }
        /// <summary>
        /// Еловая лапа
        /// </summary>
        public double SprucePaw { get; set; }
        /// <summary>
        /// Хворост, веточный корм
        /// </summary>
        public double Brushwood { get; set; }
        /// <summary>
        /// Мох, лесная подстилка, камыш, тростник
        /// </summary>
        public double ForestFloor { get; set; }
        /// <summary>
        /// Цена за пни
        /// </summary>
        public double StumpsPrice { get; set; }
        /// <summary>
        /// Цена за кору
        /// </summary>
        public double BarkPrice { get; set; }
        /// <summary>
        /// Цена за луб
        /// </summary>
        public double LubPrice { get; set; }
        /// <summary>
        /// Цена за пихтовую лапу
        /// </summary>
        public double BirchBarkPrice { get; set; }
        /// <summary>
        /// Цена за пихтовую лапу
        /// </summary>
        public double FirPawPrice { get; set; }
        /// <summary>
        /// Цена за сосновую лапу
        /// </summary>
        public double PinePawPrice { get; set; }
        /// <summary>
        /// Цена за еловую лапу
        /// </summary>
        public double SprucePawPrice { get; set; }
        /// <summary>
        /// Цена за хворост, веточный корм
        /// </summary>
        public double BrushwoodPrice { get; set; }
        /// <summary>
        /// Цена за мох, лесная подстилка, камыш, тростник
        /// </summary>
        public double ForestFloorPrice { get; set; }
    }
}