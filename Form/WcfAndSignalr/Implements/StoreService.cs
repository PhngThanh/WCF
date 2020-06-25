using POS.Repository.Entities;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using POS.Repository.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace WcfAndSignalr.Implements
{
    [AspNetCompatibilityRequirements
     (
     RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed
     )]
    public class StoreService : WcfAndSignalr.Interfaces.IStoreService
    {
        POS.Repository.Entities.Services.StoreService storeService
           = ServiceManager.GetService<POS.Repository.Entities.Services.StoreService>(typeof(StoreRepository));
        public POS.Repository.Response.BaseResponse<Store> Add(Store t)
        {
            throw new NotImplementedException();
        }

        public POS.Repository.Response.BaseResponse<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public POS.Repository.Response.BaseResponse<Store> Edit(Store t, string id)
        {
            throw new NotImplementedException();
        }

        public POS.Repository.Response.BaseResponse<Store> GetById(string id)
        {
            return storeService.GetById(id);
        }

        public POS.Repository.Response.BaseResponse<Store> GetCodeByStoreId(string id, string authorizeCode)
        {
            throw new NotImplementedException();
        }

        public POS.Repository.Response.BaseResponse<int> GetCount()
        {
            throw new NotImplementedException();
        }

        //***********************************************************************************
        //Ham generate code ne !!! 
        public POS.Repository.Response.BaseResponse<Store> GetGenerateCode(string id)
        {
            return storeService.GetNewGenerateCodeByStoreId(id);
        }
        //***********************************************************************************

        public POS.Repository.Response.BaseResponse<IEnumerable<Store>> Gets()
        {
            return storeService.GetStores();
        }

        public IEnumerable<Store> GetStores()
        {
            return storeService.GetAllStores();
        }

        public POS.Repository.Response.BaseResponse<bool> Login(string id, string authorizeCode)
        {
            return storeService.Login(id, authorizeCode);
        }

        //public POS.Repository.Response.StoreResponse<IEnumerable<Store>> GetsStores()
        //{
        //    return storeService.GetAllStores();
        //}


    }
}
