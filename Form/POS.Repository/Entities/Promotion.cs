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
    
    public partial class Promotion
    {
        public int PromotionID { get; set; }
        public string PromotionCode { get; set; }
        public string PromotionName { get; set; }
        public string PromotionClassName { get; set; }
        public string Description { get; set; }
        public string ImageCss { get; set; }
        public int ApplyLevel { get; set; }
        public int GiftType { get; set; }
        public bool IsForMember { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public Nullable<int> ApplyFromTime { get; set; }
        public Nullable<int> ApplyToTime { get; set; }
        public Nullable<int> PromotionType { get; set; }
        public Nullable<bool> IsVoucher { get; set; }
        public Nullable<bool> IsApplyOnce { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}