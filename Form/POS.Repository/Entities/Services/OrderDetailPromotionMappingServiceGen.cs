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
    
    public partial class OrderDetailPromotionMappingService:SkyWeb.DatVM.Data.BaseService<OrderDetailPromotionMapping>, IOrderDetailPromotionMappingService
    {
      public OrderDetailPromotionMappingService(SkyWeb.DatVM.Data.IUnitOfWork unitOfWork, IOrderDetailPromotionMappingRepository repository)
                : base(unitOfWork, repository)
            {
            }
        
    	}
        public partial interface IOrderDetailPromotionMappingService :  SkyWeb.DatVM.Data.IBaseService<OrderDetailPromotionMapping>
        {
        }
}
