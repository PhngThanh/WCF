using POS.Repository.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Services
{
    public partial class OrderDetailService
    {
        public void RemoveRange(IEnumerable<OrderDetail> list)
        {
            foreach (var item in list)
            {
                var dbItem = repository.Get(item.OrderDetailID);
                if (dbItem != null)
                {
                    repository.Delete(dbItem);
                }
            }
            repository.Save();
        }
        public IEnumerable<SortedProduct> GetMostProducts()
        {
            var productIds = repository.Get().GroupBy(g => g.ProductCode).OrderByDescending(o => o.Count());
            return productIds.Select(s=>new SortedProduct (){ Code=s.Key,Count=s.Count()}).AsEnumerable();
        }
    }
    public class SortedProduct
    {
        public int Count { get; set; }
        public string Code { get; set; }
    }
    public partial interface IOrderDetailService
    {
        void RemoveRange(IEnumerable<OrderDetail> list);
        IEnumerable<SortedProduct> GetMostProducts();
    }
}
