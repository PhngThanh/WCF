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
    
    public partial class CategoryViewModel:SkyWeb.DatVM.Mvc.BaseEntityViewModel<Category>
    {
        public virtual int Id { get; set; }
        public virtual int Code { get; set; }
        public virtual string Name { get; set; }
        public virtual int Type { get; set; }
        public virtual int DisplayOrder { get; set; }
        public virtual bool IsDisplayed { get; set; }
        public virtual bool IsUsed { get; set; }
        public virtual Nullable<int> IsExtra { get; set; }
        public virtual string AdjustmentNote { get; set; }
        public virtual string ImageFontAwsomeCss { get; set; }
        public virtual Nullable<int> ParentCateId { get; set; }
    	public CategoryViewModel() : base() { }
            public CategoryViewModel(Category entity) : base(entity) { }
    }
}
