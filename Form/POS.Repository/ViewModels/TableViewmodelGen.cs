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
    
    public partial class TableViewModel:SkyWeb.DatVM.Mvc.BaseEntityViewModel<Table>
    {
        public virtual int Id { get; set; }
        public virtual string Number { get; set; }
        public virtual string Text { get; set; }
        public virtual Nullable<int> Status { get; set; }
        public virtual int DisplayOrder { get; set; }
        public virtual bool IsCircle { get; set; }
        public virtual int TableRow { get; set; }
        public virtual int TableColumn { get; set; }
        public virtual int SpanTableRow { get; set; }
        public virtual int SpanTableColumn { get; set; }
        public virtual int Floor { get; set; }
        public virtual Nullable<int> CurrentOrderId { get; set; }
        public virtual Nullable<System.DateTime> CurrentOrderDate { get; set; }
        public virtual Nullable<int> ForOrderType { get; set; }
    	public TableViewModel() : base() { }
            public TableViewModel(Table entity) : base(entity) { }
    }
}