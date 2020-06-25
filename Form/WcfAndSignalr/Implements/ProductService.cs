using POS.Repository.Entities;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using POS.Repository.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using WcfAndSignalr.Interfaces;

namespace WcfAndSignalr.Implements
{
    [AspNetCompatibilityRequirements
       (
       RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed
       )]
    public class ProductService : WcfAndSignalr.Interfaces.IProductService
    {
        private POS.Repository.Entities.Services.ProductService productService
            = ServiceManager.GetService<POS.Repository.Entities.Services.ProductService>(typeof(ProductRepository));

        public POS.Repository.Response.BaseResponse<Product> Add(Product t)
        {
            return productService.Add(t);
        }

        public POS.Repository.Response.BaseResponse<bool> Delete(string id)
        {
            return productService.Delete(id);
        }

        public POS.Repository.Response.BaseResponse<Product> Edit(Product t, string id)
        {
            return productService.Edit(t, id);
        }

        public POS.Repository.Response.BaseResponse<Product> GetById(string id)
        {
            return productService.GetById(id);
        }

        public POS.Repository.Response.BaseResponse<int> GetCount()
        {
            return productService.GetCount();
        }

        public POS.Repository.Response.BaseResponse<IEnumerable<Product>> Gets()
        {
            return productService.GetProductsByDictionary(Utils.Utils.GetFromQueryString2<Product>());
        }
    }
}
