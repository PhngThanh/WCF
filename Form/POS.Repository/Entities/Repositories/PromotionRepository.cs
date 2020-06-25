using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Repositories
{
    public partial class PromotionRepository
    {
        public void AddRangePromotions(IEnumerable<Promotion> list)
        {
            dbSet.AddRange(list);
            Save();
        }
        public void AddPromotion(Promotion promotion)
        {
            dbSet.Add(promotion);
            Save();
        }
        public Promotion GetPromotionById(int id)
        {
            return dbSet.FirstOrDefault(p => p.PromotionID == id);
        }

    }

    public partial interface IPromotionRepository
    {
        void AddRangePromotions(IEnumerable<Promotion> list);
        void AddPromotion(Promotion promotion);
        Promotion GetPromotionById(int id);
    }
}
