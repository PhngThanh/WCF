using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ViewModels
{
    public partial class OrderDetailPromotionMappingEditViewModel : OrderDetailPromotionMappingViewModel
    {
        public OrderDetailEditViewModel OrderDetailEditViewModel { get; set; }
        //public List<OrderDetailEditViewModel> OrderDetailEditViewModels { get; set; }

        public OrderDetailPromotionMappingEditViewModel()
        {
            //OrderDetailEditViewModels = new List<OrderDetailEditViewModel>();
        }

        public OrderDetailPromotionMappingEditViewModel(OrderDetailPromotionMappingViewModel orginal, IMapper mapper)
        {
            mapper.Map(orginal, this);
        }
    }
}
