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
    
    public partial class Account
    {
        public string AccountId { get; set; }
        public string AccountPassword { get; set; }
        public string StaffName { get; set; }
        public string Role { get; set; }
        public bool IsUsed { get; set; }
    }
}
