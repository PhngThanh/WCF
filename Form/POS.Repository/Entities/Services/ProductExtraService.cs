using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Repository.Entities.Repositories;

namespace POS.Repository.Entities.Services
{
    public partial class ProductExtraService
    {
        private ProductExtraRepository _productExtraRepository;

        public void DeleteAllProductExtras()
        {
            var productExtraRepository = GetProductExtraRepository();
            productExtraRepository.DeleteRangeProductExtras(productExtraRepository.Get());
        }

        public void AddRangeProductExtras(IEnumerable<ProductExtra> list)
        {
            var productExtraRepository = GetProductExtraRepository();
            productExtraRepository.AddRangeProductExtras(list);
        }

        public IEnumerable<ProductExtra> GetAvailableProductExtras()
        {
            return repository.Get(pe => pe.IsUsed);
        }

        private ProductExtraRepository GetProductExtraRepository()
        {
            if (_productExtraRepository == null)
            {
                _productExtraRepository = new ProductExtraRepository(ServiceManager.GetDbEntities());
            }

            return _productExtraRepository;
        }
    }

    public partial interface IProductExtraService
    {
        void DeleteAllProductExtras();
        void AddRangeProductExtras(IEnumerable<ProductExtra> list);
        IEnumerable<ProductExtra> GetAvailableProductExtras();
    }
}
