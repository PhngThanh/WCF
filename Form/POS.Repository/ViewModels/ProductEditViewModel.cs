using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ViewModels
{
    public class ProductEditViewModel : ProductViewModel
    {
        public ProductEditViewModel()
        {
        }

        public ProductEditViewModel(ProductViewModel orginal, IMapper mapper)
        {
            mapper.Map(orginal, this);
        }
    }
}
