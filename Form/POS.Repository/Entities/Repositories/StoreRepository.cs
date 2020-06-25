using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Repositories
{

    public partial interface IStoreRepository
    {
        int GetCount(Expression<Func<Store, bool>> predicate);
        int GetCount();
        Store GetStoreById(int storeId);
    }

    public partial class StoreRepository
    {
        public int GetCount(Expression<Func<Store, bool>> predicate)
        {
            return dbSet.Where(predicate).Count();
        }
        public int GetCount()
        {
            return dbSet.Count();
        }
        public Store GetStoreById(int storeId)
        {
            return dbSet.FirstOrDefault(c => c.Id == storeId);
        }

    }
}
