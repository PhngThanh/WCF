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
    
    public partial class OrderPromotionMapping
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PromotionCode { get; set; }
        public string PromotionDetailCode { get; set; }
        public int MappingIndex { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<int> DiscountRate { get; set; }
        public Nullable<int> TmpMappingId { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
