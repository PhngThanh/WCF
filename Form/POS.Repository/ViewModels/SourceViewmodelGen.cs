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
    
    public partial class SourceViewModel:SkyWeb.DatVM.Mvc.BaseEntityViewModel<Source>
    {
        public virtual int SourceId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string ContactPerson { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
    	public SourceViewModel() : base() { }
            public SourceViewModel(Source entity) : base(entity) { }
    }
}
