using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Repositories
{
    public partial class ProductRepository
    {
        public void AddRangeProducts(IEnumerable<Product> list)
        {
            dbSet.AddRange(list);

            Save();
        }

        public Product GetProductById(int productId)
        {
            return dbSet.FirstOrDefault(p => p.ProductId == productId);
        }
    }

    public partial interface IProductRepository
    {
        void AddRangeProducts(IEnumerable<Product> list);
        Product GetProductById(int productId);
    }
}
