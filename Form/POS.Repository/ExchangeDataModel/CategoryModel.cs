using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
   public class CategoryModel
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsUsed { get; set; }
        public int IsExtra { get; set; }
        public string AdjustmentNote { get; set; }
        public string ImageFontAwsomeCss { get; set; }
        public Nullable<int> ParentCateId { get; set; }
    }

    public class ProductCategoryApiViewModel
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsUsed { get; set; }
        public int IsExtra { get; set; }
        public string AdjustmentNote { get; set; }
        public string ImageFontAwsomeCss { get; set; }
        public int? ParentCateId { get; set; }
    }

    public class CategoryExtraMappingApiViewModel
    {
        public int CategoryExtraId { get; set; }
        public int PrimaryCategoryId { get; set; }
        public int ExtraCategoryId { get; set; }
        public bool IsEnable { get; set; }
    }

    public class ProductCategoryExtraMappingViewModel
    {
        public List<ProductCategoryApiViewModel> ProductCategory { get; set; }
        public List<CategoryExtraMappingApiViewModel> CategoryExtra { get; set; }
    }

}
