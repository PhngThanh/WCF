//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.Repository.ViewModels
{
      using POS.Repository.Entities;
    using System;
    using System.Collections.Generic;
    
    public partial class AccountViewModel:SkyWeb.DatVM.Mvc.BaseEntityViewModel<Account>
    {
        public virtual string AccountId { get; set; }
        public virtual string AccountPassword { get; set; }
        public virtual string StaffName { get; set; }
        public virtual string Role { get; set; }
        public virtual bool IsUsed { get; set; }
    	public AccountViewModel() : base() { }
            public AccountViewModel(Account entity) : base(entity) { }
    }
}
