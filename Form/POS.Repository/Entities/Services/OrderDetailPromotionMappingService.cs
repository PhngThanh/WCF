using POS.Repository.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Services
{
    public partial class OrderDetailPromotionMappingService
    {
        public void RemoveRange(IEnumerable<OrderDetailPromotionMapping> list)
        {
            foreach (var item in list)
            {
                var dbItem = repository.Get(item.Id);
                if (dbItem != null)
                {
                    repository.Delete(dbItem);
                }
            }
            repository.Save();
        }
    }

    public partial interface IOrderDetailPromotionMappingService
    {
        void RemoveRange(IEnumerable<OrderDetailPromotionMapping> list);
    }
}
