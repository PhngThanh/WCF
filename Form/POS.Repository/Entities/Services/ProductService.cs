using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Repository.Entities.Repositories;

namespace POS.Repository.Entities.Services
{
    public partial interface IProductService
    {
        IEnumerable<Product> GetProducts(IEnumerable<int> productIds);
        IEnumerable<Product> GetAvailableSingleProducts();
        IEnumerable<Product> GetAvailableChildrenProducts();
        IEnumerable<Product> GetAllAvailableProducts();
        IEnumerable<Product> GetProductsToUpdate();
        void AddProductsRange(IEnumerable<Product> products);

        Response.BaseResponse<Product> Add(Product t);
        Response.BaseResponse<Product> Edit(Product t, string id);
        Response.BaseResponse<bool> Delete(string id);
        Response.BaseResponse<Product> GetById(string id);
        Response.BaseResponse<IEnumerable<Product>> GetAllProducts();
        Response.BaseResponse<IEnumerable<Product>> GetProductsByDictionary(Dictionary<string, object> dictionary);
        Response.BaseResponse<int> GetCount();

    }

    public partial class ProductService
    {
        private const string ORDER_BY = "ProductId";

        public IEnumerable<Product> GetAvailableSingleProducts()
        {
            // Lấy tất cả các sản phẩm không phải là sản phầm con
            return repository.Get(a => a.IsAvailable == true && a.IsUsed == true 
            && a.GeneralProductId == null);
        }
        public IEnumerable<Product> GetAvailableChildrenProducts()
        {
            // Lấy tất cả các sản phẩm không phải là sản phầm con
            return repository.Get(a => a.IsAvailable == true && a.IsUsed == true && a.GeneralProductId != null);
        }
        public IEnumerable<Product> GetAllAvailableProducts()
        {
            // Lấy tất cả sản phẩm, bao gồm cả sản phẩm con
            return repository.Get(a => a.IsAvailable == true && a.IsUsed == true);
        }
        public IEnumerable<Product> GetProductsToUpdate()
        {
            return repository.Get(a => a.IsUsed);
        }

        public void AddProductsRange(IEnumerable<Product> products)
        {
            ProductRepository productRepository = new ProductRepository(ServiceManager.GetDbEntities());

            productRepository.AddRangeProducts(products);
        }

        //public void DeactiveListProduct(List<Product> productList)
        //{
        //    productList.ForEach(p => p.IsUsed = false);
        //    Save();
        //}
        public IEnumerable<Product> GetProducts(IEnumerable<int> productIds)
        {
            // Lấy tất cả các sản phẩm không phải là sản phầm con
            return repository.Get(a => a.IsAvailable == true && a.IsUsed == true 
            && productIds.Contains(a.ProductId)
            );
        }


        public Response.BaseResponse<Product> Add(Product t)
        {
            var result = new POS.Repository.Response.BaseResponse<Product>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            if (t == null)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (!IsValidProduct(t))
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (repository.FirstOrDefault(p => p.Code == t.Code) != null)
            {
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = "ProductCode is duplicated";
                return result;
            }

            try
            {
                repository.Add(t);
                repository.Save();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.CREATED;
                result.Data = t;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }

        public Response.BaseResponse<IEnumerable<Product>> GetAllProducts()
        {
            var result = new Response.BaseResponse<IEnumerable<Product>>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            try
            {
                IEnumerable<Product> products = repository.Get();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = products;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
            }
            return result;
        }

        public Response.BaseResponse<IEnumerable<Product>> GetProductsByDictionary(Dictionary<string, object> dictionary)
        {
            var result = new Response.BaseResponse<IEnumerable<Product>>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            try
            {
                IQueryable<Product> entities = Utils.FilterIQueryableByDictionary(repository.Get(), dictionary, ORDER_BY);
                entities = Utils.PagingIQueryable(entities, dictionary, ORDER_BY);

                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = entities.ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = ex is ArgumentNullException || ex is FormatException || ex is OverflowException 
                    ? (int)ResponseStatusEnum.BADREQUEST : (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
            }
            return result;
        }

        public Response.BaseResponse<int> GetCount()
        {
            var result = new Response.BaseResponse<int>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
                Data = 0
            };
            try
            {
                int count = repository.Get().Count();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = count;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
            }
            return result;
        }

        public Response.BaseResponse<Product> GetById(string id)
        {
            int productId = 0;
            var result = new POS.Repository.Response.BaseResponse<Product>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                productId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            Product product = repository.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
            }
            else
            {
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = product;
            }

            return result;
        }

        public Response.BaseResponse<bool> Delete(string id)
        {
            int productId = 0;
            var result = new POS.Repository.Response.BaseResponse<bool>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
                Data = false
            };

            try
            {
                productId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            Product product = repository.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
                return result;
            }
            else
            {
                try
                {
                    repository.Delete(product);
                    repository.Save();
                    result.Success = true;
                    result.Status = (int)ResponseStatusEnum.NOCONTENT;
                    result.Data = true;
                    return result;
                }
                catch (System.Exception ex)
                {
                    result.Status = (int)ResponseStatusEnum.ERROR;
                    result.Success = false;
                    result.Data = true;
                    result.Message = ex.Message;
                    return result;
                }
            }
        }

        public Response.BaseResponse<Product> Edit(Product t, string id)
        {
            int productId = 0;

            var result = new POS.Repository.Response.BaseResponse<Product>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                productId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (t == null)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (!IsValidProduct(t))
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }
            ProductRepository productRepository = new ProductRepository(ServiceManager.GetDbEntities());
            Product product = productRepository.GetProductById(productId);
            if (product == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
                return result;
            }

            try
            {
                product = (Product) AutoMapper.Mapper.Map(t, typeof(Product), typeof(Product));
                repository.Edit(product);
                repository.Save();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = t;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }

        private bool IsValidProduct(Product p)
        {
            if(string.IsNullOrEmpty(p.Code))
            {
                return false;
            }
            if(p.Code.Length > 50)
            {
                return false;
            }

            if(!string.IsNullOrEmpty(p.ProductName))
            {
                if (p.ProductName.Length > 500)
                {
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(p.ShortName))
            {
                if (p.ShortName.Length > 50)
                {
                    return false;
                }
            }

            return true;
        }
    }


}
