//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.Repository.Entities.Repositories
{
    using POS.Repository.Entities.Repositories;
    using System;
    using System.Collections.Generic;
    
    public partial class TableRepository:SkyWeb.DatVM.Data.BaseRepository<Table>, ITableRepository
    {
      public TableRepository(System.Data.Entity.DbContext dbContext) : base(dbContext)
            {
            }
        
    	}
        public partial interface ITableRepository :  SkyWeb.DatVM.Data.IBaseRepository<Table>
        {
        }
}