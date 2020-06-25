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
    class PromotionDetailService : WcfAndSignalr.Interfaces.IPromotionDetailService
    {
        POS.Repository.Entities.Services.PromotionDetailService promotionDetailService
            = ServiceManager.GetService<POS.Repository.Entities.Services.PromotionDetailService>(typeof(PromotionDetailRepository));

        public POS.Repository.Response.BaseResponse<PromotionDetail> Add(PromotionDetail t)
        {
            return promotionDetailService.Add(t);
        }

        public POS.Repository.Response.BaseResponse<bool> Delete(string id)
        {
            return promotionDetailService.Delete(id);
        }

        public POS.Repository.Response.BaseResponse<PromotionDetail> Edit(PromotionDetail t, string id)
        {
            return promotionDetailService.Edit(t, id);
        }

        public POS.Repository.Response.BaseResponse<PromotionDetail> GetById(string id)
        {
            return promotionDetailService.GetById(id);
        }

        public POS.Repository.Response.BaseResponse<int> GetCount()
        {
            return promotionDetailService.GetCount();
        }

        public POS.Repository.Response.BaseResponse<IEnumerable<PromotionDetail>> Gets()
        {
            return promotionDetailService.GetPromotionDetailsByDictionary(
                Utils.Utils.GetFromQueryString2<PromotionDetail>());
        }
    }
}
