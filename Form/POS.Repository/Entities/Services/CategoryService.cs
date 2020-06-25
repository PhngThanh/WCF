using POS.Repository.Entities.Repositories;
using POS.Repository.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Repository.Entities.Services
{
    public partial interface ICategoryService
    {
        IEnumerable<Category> GetAvailableCategories();
        IEnumerable<Category> GetExtraCategories();
        IEnumerable<Category> GetOtherCategories();
        BaseResponse<Category> Add(Category t);
        BaseResponse<Category> Edit(Category t, string id);
        BaseResponse<bool> Delete(string id);
        BaseResponse<Category> GetById(string id);
        BaseResponse<int> GetCount();
        BaseResponse<IEnumerable<Category>> GetAllCategories();
        BaseResponse<IEnumerable<Category>> GetCategoriesByDictionary(Dictionary<string, object> dictionary);

    }

    public partial class CategoryService
    {
        private const string ORDER_BY = "Id";

        public IEnumerable<Category> GetAvailableCategories()
        {
            return repository.Get(c => c.IsUsed && c.IsDisplayed);
        }
        public IEnumerable<Category> GetExtraCategories()
        {
            return repository.Get(c => c.IsUsed && c.IsDisplayed && c.IsExtra == 1);
        }
        public IEnumerable<Category> GetOtherCategories()
        {
            return repository.Get(c => c.IsUsed && c.Type != 1);
        }

        public BaseResponse<Category> Add(Category t)
        {
            var result = new POS.Repository.Response.BaseResponse<Category>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            if (t == null)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (!IsValidCategory(t))
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (repository.FirstOrDefault(cate => cate.Code == t.Code) != null)
            {
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = "CategoryCode is duplicated";
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

        public BaseResponse<Category> Edit(Category t, string id)
        {
            int categoryId = 0;
            
            var result = new POS.Repository.Response.BaseResponse<Category>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                categoryId = int.Parse(id);
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

            if (!IsValidCategory(t))
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }
            CategoryRepository categoryRepository = new CategoryRepository(ServiceManager.GetDbEntities());
            Category category = categoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
                return result;
            }

            try
            {
                category = (Category) AutoMapper.Mapper.Map(t, typeof(Category), typeof(Category));
                repository.Edit(category);
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

        public BaseResponse<bool> Delete(string id)
        {
            int categoryId = 0;
            var result = new POS.Repository.Response.BaseResponse<bool>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
                Data = false
            };

            try
            {
                categoryId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            Category category = repository.FirstOrDefault(cate => cate.Id == categoryId);
            if(category == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
                return result;
            } else
            {
                try
                {
                    repository.Delete(category);
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

        public BaseResponse<Category> GetById(string id)
        {
            int categoryId = 0;
            var result = new POS.Repository.Response.BaseResponse<Category>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                categoryId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            Category category = repository.FirstOrDefault(cate => cate.Id == categoryId);
            if(category == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
            } else
            {
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = category;
            }

            return result;
        }

        public BaseResponse<int> GetCount()
        {
            int count = 0;
            var result = new BaseResponse<int>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
                Data = 0
            };

            try
            {
                CategoryRepository cateRepository = new CategoryRepository(ServiceManager.GetDbEntities());
                count = cateRepository.GetCount();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = count;
            }
            catch (System.Exception)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Data = 0;
            }
            return result;
        }

        public BaseResponse<IEnumerable<Category>> GetAllCategories()
        {
            var result = new BaseResponse<IEnumerable<Category>>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            try
            {
                CategoryRepository categoryRepository = new CategoryRepository(ServiceManager.GetDbEntities());
                IEnumerable<Category> categories = categoryRepository.Get();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = categories;
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

        public BaseResponse<IEnumerable<Category>> GetCategoriesByDictionary(Dictionary<string, object> dictionary)
        {
            var result = new BaseResponse<IEnumerable<Category>>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            try
            {
                IQueryable<Category> entities = Utils.FilterIQueryableByDictionary(repository.Get(), dictionary, ORDER_BY);
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
                result.Data = null;
            }
            return result;
        }

        private bool IsValidCategory(Category t)
        {
            if (t == null)
            {
                return false;
            }
            if(string.IsNullOrEmpty(t.Name) || string.IsNullOrEmpty(t.ImageFontAwsomeCss))
            {
                return false;
            }

            if (t.Name.Length > 50)
            {
                return false;
            }
            if (t.ImageFontAwsomeCss.Length > 250)
            {
                return false;
            }
            return true;
        }



    }
}
