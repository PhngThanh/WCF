//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PromotionDetail
    {
        public int PromotionDetailID { get; set; }
        public string PromotionCode { get; set; }
        public string RegExCode { get; set; }
        public Nullable<double> MinOrderAmount { get; set; }
        public Nullable<double> MaxOrderAmount { get; set; }
        public string BuyProductCode { get; set; }
        public Nullable<int> MinBuyQuantity { get; set; }
        public Nullable<int> MaxBuyQuantity { get; set; }
        public string GiftProductCode { get; set; }
        public string PromotionDetailCode { get; set; }
        public Nullable<int> GiftQuantity { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<int> DiscountRate { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
