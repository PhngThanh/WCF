using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Services
{
    public partial interface ICategoryExtraService
    {
        IEnumerable<CategoryExtra> GetAvailableCategoriesExtra();
    }

    public partial class CategoryExtraService
    {
        public IEnumerable<CategoryExtra> GetAvailableCategoriesExtra()
        {
            return repository.Get(c => c.IsEnable);
        }
    }
}
