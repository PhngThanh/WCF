using POS.Repository.Entities.Repositories;
using POS.Repository.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Services
{
    public partial interface IStoreService
    {
        IEnumerable<Store> GetAllStores();
    }
    public partial class StoreService
    {
        public BaseResponse<IEnumerable<Store>> GetStores()
        {
            var result = new BaseResponse<IEnumerable<Store>>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            try
            {
                StoreRepository storeRepository = new StoreRepository(ServiceManager.GetDbEntities());
                IEnumerable<Store> stores = storeRepository.Get();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = stores;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
                result.Data = null;
            }
            return result;
        }
        public IEnumerable<Store> GetAllStores()
        {
            IEnumerable<Store> stores; 
            try
            {
                StoreRepository storeRepository = new StoreRepository(ServiceManager.GetDbEntities());
                 stores = storeRepository.Get();
                return stores;
            }
            catch (System.Exception ex)
            {
                //do something 
            }
            return null;
            
        }

        public BaseResponse<Store> GetById(string id)
        {
            int storeId = 0;
            var result = new POS.Repository.Response.BaseResponse<Store>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                storeId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            Store store = repository.FirstOrDefault(s => s.Id == storeId);
            if (store == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
            }
            else
            {
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = store;
            }

            return result;
        }

        public BaseResponse<Store> GetNewGenerateCodeByStoreId(string id)
        {
            int storeId = 0;
            var result = new POS.Repository.Response.BaseResponse<Store>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                storeId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            Store store = repository.FirstOrDefault(s => s.Id == storeId);
            if (store == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
            }
            else
            {
                store.AuthorizeCode = createNewCode();
                repository.Edit(store);
                repository.Save();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = store;
            }

            return result;
        }

        //***********************************************************************************
        //ham generateCode
        public string createNewCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        //***********************************************************************************

        //ham check login
        public BaseResponse<bool> Login(string id, string authorizeCode)
        {
            int storeId = 0;
            var result = new POS.Repository.Response.BaseResponse<bool>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            if(id == null || authorizeCode == null){
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            try
            {
                storeId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            //kt sai
            Store db_Store = repository.FirstOrDefault(s => s.Id == storeId && s.AuthorizeCode.Equals(authorizeCode));
            if(db_Store == null)
            {
                result.Status = (int)ResponseStatusEnum.UNAUTHORIZE;
                result.Message = "Wrong password";
                return result;
            }
            if (db_Store.Id == storeId && db_Store.AuthorizeCode.Equals(authorizeCode)){
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
            }

            return result;
        }
        //
    }
}
