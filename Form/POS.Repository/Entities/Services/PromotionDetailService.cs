using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using POS.Repository.Entities.Repositories;

namespace POS.Repository.Entities.Services
{
    public partial interface IPromotionDetailService
    {
        void AddPromotionDetailsRange(IEnumerable<PromotionDetail> list);
        Response.BaseResponse<PromotionDetail> Add(PromotionDetail t);
        Response.BaseResponse<bool> Delete(string id);
        Response.BaseResponse<PromotionDetail> Edit(PromotionDetail t, string id);
        Response.BaseResponse<PromotionDetail> GetById(string id);
        Response.BaseResponse<int> GetCount();
        Response.BaseResponse<IEnumerable<PromotionDetail>> GetAllPromotionDetails();
        Response.BaseResponse<IEnumerable<PromotionDetail>> GetPromotionDetailsByDictionary(Dictionary<string, object> dictionary);
    }

    public partial class PromotionDetailService
    {
        private const string ORDER_BY = "PromotionDetailID";

        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void AddPromotionDetailsRange(IEnumerable<PromotionDetail> list)
        {

            PromotionDetailRepository promotionDetailRepository = new PromotionDetailRepository(ServiceManager.GetDbEntities());
            // Update one per line item .
            foreach (var item in list)
            {
                try
                {
                    promotionDetailRepository.AddRangePromotionDetail(item);
                }
                catch (Exception ex)
                {
                    log.Error("Update Promotion New Line item - " + ex);
                }
            }

        }



        public Response.BaseResponse<PromotionDetail> Add(PromotionDetail t)
        {
            var result = new POS.Repository.Response.BaseResponse<PromotionDetail>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            if (t == null)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (!IsValidPromotionDetail(t))
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (repository.FirstOrDefault(p => p.PromotionDetailCode == t.PromotionDetailCode) != null)
            {
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = "PromotionDetailCode is duplicated";
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

        public Response.BaseResponse<bool> Delete(string id)
        {
            int promotionDetailID = 0;
            var result = new POS.Repository.Response.BaseResponse<bool>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
                Data = false
            };

            try
            {
                promotionDetailID = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            PromotionDetail promotionDetail = repository.FirstOrDefault(p => p.PromotionDetailID == promotionDetailID);
            if (promotionDetail == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
                return result;
            }
            else
            {
                try
                {
                    repository.Delete(promotionDetail);
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

        public Response.BaseResponse<PromotionDetail> Edit(PromotionDetail t, string id)
        {
            int promotionDetailId = 0;

            var result = new POS.Repository.Response.BaseResponse<PromotionDetail>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                promotionDetailId = int.Parse(id);
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

            if (!IsValidPromotionDetail(t))
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }
            PromotionDetailRepository promotionDetailRepository = new PromotionDetailRepository(ServiceManager.GetDbEntities());
            PromotionDetail promotionDetail = promotionDetailRepository.GetPromotionDetailById(promotionDetailId);
            if (promotionDetail == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
                return result;
            }

            try
            {
                promotionDetail = (PromotionDetail)AutoMapper.Mapper.Map(t, typeof(PromotionDetail), typeof(PromotionDetail));
                repository.Edit(promotionDetail);
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

        public Response.BaseResponse<PromotionDetail> GetById(string id)
        {
            int promDetailID = 0;
            var result = new POS.Repository.Response.BaseResponse<PromotionDetail>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                promDetailID = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            PromotionDetail promotionDetail = repository.FirstOrDefault(p => p.PromotionDetailID == promDetailID);
            if (promotionDetail == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
            }
            else
            {
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = promotionDetail;
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

        public Response.BaseResponse<IEnumerable<PromotionDetail>> GetAllPromotionDetails()
        {
            var result = new Response.BaseResponse<IEnumerable<PromotionDetail>>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            try
            {
                IEnumerable<PromotionDetail> promotionDetails = repository.Get();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = promotionDetails;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
            }
            return result;
        }
        
        public Response.BaseResponse<IEnumerable<PromotionDetail>> GetPromotionDetailsByDictionary(Dictionary<string, object> dictionary)
        {
            var result = new Response.BaseResponse<IEnumerable<PromotionDetail>>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            try
            {
                IQueryable<PromotionDetail> entities = Utils.FilterIQueryableByDictionary(repository.Get(), dictionary, ORDER_BY);
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

        private bool IsValidPromotionDetail(PromotionDetail pm)
        {
            if (string.IsNullOrEmpty(pm.PromotionCode) || string.IsNullOrEmpty(pm.PromotionDetailCode))
            {
                return false;
            }

            if (pm.PromotionCode.Length > 250 || pm.PromotionDetailCode.Length > 250)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(pm.RegExCode))
            {
                if (pm.RegExCode.Length > 50)
                {
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(pm.BuyProductCode))
            {
                if (pm.BuyProductCode.Length > 250)
                {
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(pm.GiftProductCode))
            {
                if (pm.GiftProductCode.Length > 50)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
