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
    
    public partial class CategoryExtra
    {
        public int CategoryExtraId { get; set; }
        public int PrimaryCategoryCode { get; set; }
        public int ExtraCategoryCode { get; set; }
        public bool IsEnable { get; set; }
    }
}
