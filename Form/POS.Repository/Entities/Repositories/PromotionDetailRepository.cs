using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Repositories
{
    public partial class PromotionDetailRepository
    {
        public void AddRangePromotionDetails(IEnumerable<PromotionDetail> list)
        {
            dbSet.AddRange(list);
            Save();
        }
        public void AddRangePromotionDetail(PromotionDetail promotionDetail)
        {
            dbSet.Add(promotionDetail);
            Save();
        }
        public PromotionDetail GetPromotionDetailById(int id)
        {
            return dbSet.FirstOrDefault(p => p.PromotionDetailID == id);
        }
    }

    public partial interface IPromotionDetailRepository
    {
        void AddRangePromotionDetails(IEnumerable<PromotionDetail> list);
        void AddRangePromotionDetail(PromotionDetail promotionDetail);
        PromotionDetail GetPromotionDetailById(int id);
    }
}
