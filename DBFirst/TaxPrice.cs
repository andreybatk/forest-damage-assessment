//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaxPrice
    {
        public int ID { get; set; }
        public string TaxPriceCode { get; set; }
        public string SubjectRF { get; set; }
        public string Area { get; set; }
        public string TaxPriceDesc { get; set; }
        public string Breed { get; set; }
        public Nullable<int> RankTax { get; set; }
        public string TransportationDistance { get; set; }
        public Nullable<decimal> PriceLarge { get; set; }
        public Nullable<decimal> PriceAverage { get; set; }
        public Nullable<decimal> PriceSmall { get; set; }
        public Nullable<decimal> Firewood { get; set; }
    }
}
