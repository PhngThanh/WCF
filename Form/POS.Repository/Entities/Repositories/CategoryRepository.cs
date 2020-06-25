using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Repositories
{
    public partial interface ICategoryRepository
    {
        int GetCount(Expression<Func<Category, bool>> predicate);
        int GetCount();
        Category GetCategoryById(int categoryId);
    }

    public partial  class CategoryRepository
    {
        public int GetCount(Expression<Func<Category, bool>> predicate)
        {
           return dbSet.Where(predicate).Count();
        }
        public int GetCount()
        {
            return dbSet.Count();
        }
        public Category GetCategoryById(int categoryId)
        {
            return dbSet.FirstOrDefault(c => c.Id == categoryId);
        }
        
    }

}
