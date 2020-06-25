

using POS.Repository;
using POS.Repository.Entities;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using WcfAndSignalr.Interfaces;

namespace WcfAndSignalr.Implements
{
    [AspNetCompatibilityRequirements
      (
      RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed
      )]
    public class CategoryService : WcfAndSignalr.Interfaces.ICategoryService
    {

        POS.Repository.Entities.Services.CategoryService categoryService
            = ServiceManager.GetService<POS.Repository.Entities.Services.CategoryService>(typeof(CategoryRepository));

        public POS.Repository.Response.BaseResponse<Category> Add(Category t)
        {
            return categoryService.Add(t);
        }

        public POS.Repository.Response.BaseResponse<bool> Delete(string id)
        {
            return categoryService.Delete(id);
        }

        public POS.Repository.Response.BaseResponse<Category> Edit(Category t, string id)
        {
            return categoryService.Edit(t, id);
        }

        public POS.Repository.Response.BaseResponse<Category> GetById(string id)
        {
            return categoryService.GetById(id);
        }

        public POS.Repository.Response.BaseResponse<int> GetCount()
        {
            return categoryService.GetCount();
        }

        public POS.Repository.Response.BaseResponse<IEnumerable<Category>> Gets()
        {
            return categoryService.GetCategoriesByDictionary(Utils.Utils.GetFromQueryString2<Category>());
        }

    }
}
