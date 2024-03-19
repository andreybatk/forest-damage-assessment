using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestDamageAssessment.DB.Models
{
    public class TaxPrice
    {
        public int ID { get; set; }
        public string TaxPriceCode { get; set; }
        public string SubjectRF { get; set; }
        public string Area { get; set; }
        public string TaxPriceDesc { get; set; }
        public string Breed { get; set; }
        public int? RankTax { get; set; }
        public string TransportationDistance { get; set; }
        public decimal? PriceLarge { get; set; }
        public decimal? PriceAverage { get; set; }
        public decimal? PriceSmall { get; set; }
        public decimal? Firewood { get; set; }
    }
}
