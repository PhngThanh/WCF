using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using POS.Repository.Entities.Repositories;

namespace POS.Repository.Entities.Services
{
    public partial class PromotionService
    {
        private const string ORDER_BY = "PromotionID";

        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void AddPromotionsRange(IEnumerable<Promotion> list)
        {
            PromotionRepository promotionRepository = new PromotionRepository(ServiceManager.GetDbEntities());
            foreach (var item in list)
            {
                try
                {
                    promotionRepository.AddPromotion(item);
                }
                catch (Exception ex)
                {
                    log.Error("Update Promotion New Line item - " + ex);
                }
            }
        }
        public IEnumerable<Promotion> GetAvailablePromotions()
        {
            return repository.Get(a => a.IsActive);
        }


        public Response.BaseResponse<Promotion> Add(Promotion t)
        {
            var result = new POS.Repository.Response.BaseResponse<Promotion>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            if (t == null)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (!IsValidPromotion(t))
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (repository.FirstOrDefault(p => p.PromotionCode == t.PromotionCode) != null)
            {
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = "PromotionCode is duplicated";
                return result;
            }

            try
            {
                repository.Add(t);
                repository.Save();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.CREATED;
                result.Data = t;
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

        public Response.BaseResponse<IEnumerable<Promotion>> GetAllPromotions()
        {
            var result = new Response.BaseResponse<IEnumerable<Promotion>>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            try
            {
                IEnumerable<Promotion> products = repository.Get().OrderBy(p => p.PromotionID);
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = products;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
            }
            return result;
        }
        public Response.BaseResponse<IEnumerable<Promotion>> GetPromotionsByDictionary(Dictionary<string, object> dictionary)
        {
            var result = new Response.BaseResponse<IEnumerable<Promotion>>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            try
            {
                IQueryable<Promotion> entities = Utils.FilterIQueryableByDictionary(repository.Get(), dictionary, ORDER_BY);
                entities = Utils.PagingIQueryable(entities, dictionary, ORDER_BY);
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = entities.ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = ex is ArgumentNullException || ex is FormatException || ex is OverflowException 
                    ? (int)ResponseStatusEnum.BADREQUEST : (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
            }
            return result;
        }

        public Response.BaseResponse<int> GetCount()
        {
            var result = new Response.BaseResponse<int>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
                Data = 0
            };
            try
            {
                int count = repository.Get().Count();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = count;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
            }
            return result;
        }

        public Response.BaseResponse<Promotion> GetById(string id)
        {
            int entityId = 0;
            var result = new POS.Repository.Response.BaseResponse<Promotion>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                entityId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            Promotion entity = repository.FirstOrDefault(e => e.PromotionID == entityId);
            if (entity == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
            }
            else
            {
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = entity;
            }

            return result;
        }

        public Response.BaseResponse<bool> Delete(string id)
        {
            int promotionID = 0;
            var result = new POS.Repository.Response.BaseResponse<bool>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
                Data = false
            };

            try
            {
                promotionID = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            Promotion entity = repository.FirstOrDefault(p => p.PromotionID == promotionID);
            if (entity == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
                return result;
            }
            else
            {
                try
                {
                    repository.Delete(entity);
                    repository.Save();
                    result.Success = true;
                    result.Status = (int)ResponseStatusEnum.NOCONTENT;
                    result.Data = true;
                    return result;
                }
                catch (System.Exception ex)
                {
                    result.Status = (int)ResponseStatusEnum.ERROR;
                    result.Success = false;
                    result.Data = true;
                    result.Message = ex.Message;
                    return result;
                }
            }
        }

        public Response.BaseResponse<Promotion> Edit(Promotion t, string id)
        {
            int promotionId = 0;

            var result = new POS.Repository.Response.BaseResponse<Promotion>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                promotionId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (t == null)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (!IsValidPromotion(t))
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }
            PromotionRepository promotionRepository = new PromotionRepository(ServiceManager.GetDbEntities());
            Promotion promotion = promotionRepository.GetPromotionById(promotionId);
            if (promotion == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
                return result;
            }

            try
            {
                promotion = (Promotion)AutoMapper.Mapper.Map(t, typeof(Promotion), typeof(Promotion));
                repository.Edit(promotion);
                repository.Save();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = t;
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

        private bool IsValidPromotion(Promotion p)
        {
            if(string.IsNullOrEmpty(p.PromotionCode) || string.IsNullOrEmpty(p.PromotionName) || string.IsNullOrEmpty(p.PromotionClassName))
            {
                return false;
            }

            if(p.PromotionCode.Length > 250 || p.PromotionName.Length > 250 || p.PromotionClassName.Length > 250)
            {
                return false;
            }

            if(!string.IsNullOrEmpty(p.ImageCss))
            {
                if(p.ImageCss.Length > 50)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public partial interface IPromotionService
    {
        IEnumerable<Promotion> GetAvailablePromotions();
        void AddPromotionsRange(IEnumerable<Promotion> list);

        Response.BaseResponse<Promotion> Add(Promotion t);
        Response.BaseResponse<Promotion> Edit(Promotion t, string id);
        Response.BaseResponse<bool> Delete(string id);
        Response.BaseResponse<Promotion> GetById(string id);
        Response.BaseResponse<IEnumerable<Promotion>> GetAllPromotions();
        Response.BaseResponse<IEnumerable<Promotion>> GetPromotionsByDictionary(Dictionary<string, object> dictionary);
        Response.BaseResponse<int> GetCount();
    }
}
