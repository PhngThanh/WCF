//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.Repository.Entities.Services
{
    using POS.Repository.Entities.Repositories;
    using System;
    using System.Collections.Generic;
    
    public partial class CategoryExtraService:SkyWeb.DatVM.Data.BaseService<CategoryExtra>, ICategoryExtraService
    {
      public CategoryExtraService(SkyWeb.DatVM.Data.IUnitOfWork unitOfWork, ICategoryExtraRepository repository)
                : base(unitOfWork, repository)
            {
            }
        
    	}
        public partial interface ICategoryExtraService :  SkyWeb.DatVM.Data.IBaseService<CategoryExtra>
        {
        }
}
