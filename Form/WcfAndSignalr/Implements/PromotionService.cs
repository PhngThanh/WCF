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
    public class PromotionService : WcfAndSignalr.Interfaces.IPromotionService
    {

        private POS.Repository.Entities.Services.PromotionService promotionService
            = ServiceManager.GetService<POS.Repository.Entities.Services.PromotionService>(typeof(PromotionRepository));

        public POS.Repository.Response.BaseResponse<Promotion> Add(Promotion t)
        {
            return promotionService.Add(t);
        }

        public POS.Repository.Response.BaseResponse<bool> Delete(string id)
        {
            return promotionService.Delete(id);
        }

        public POS.Repository.Response.BaseResponse<Promotion> Edit(Promotion t, string id)
        {
            return promotionService.Edit(t, id);
        }

        public POS.Repository.Response.BaseResponse<Promotion> GetById(string id)
        {
            return promotionService.GetById(id);
        }

        public POS.Repository.Response.BaseResponse<int> GetCount()
        {
            return promotionService.GetCount();
        }

        public POS.Repository.Response.BaseResponse<IEnumerable<Promotion>> Gets()
        {
            return promotionService.GetPromotionsByDictionary(Utils.Utils.GetFromQueryString2<Promotion>());
        }
    }
}
