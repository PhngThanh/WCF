using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Repositories
{
    public partial class ProductExtraRepository
    {
        public void DeleteRangeProductExtras(IEnumerable<ProductExtra> list)
        {
            dbSet.RemoveRange(list);
            Save();
        }

        public void AddRangeProductExtras(IEnumerable<ProductExtra> list)
        {
            dbSet.AddRange(list);
            Save();
        }
    }

    public partial interface IProductExtraRepository
    {
        void DeleteRangeProductExtras(IEnumerable<ProductExtra> list);
        void AddRangeProductExtras(IEnumerable<ProductExtra> list);
    }

}
