using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ViewModels
{
    public partial class OrderPromotionMappingEditViewModel : OrderPromotionMappingViewModel
    {
        public OrderEditViewModel OrderEditViewModel { get; set; }
        //public List<OrderDetailEditViewModel> OrderDetailEditViewModels { get; set; }

        public OrderPromotionMappingEditViewModel()
        {
            //OrderDetailEditViewModels = new List<OrderDetailEditViewModel>();
        }

        public OrderPromotionMappingEditViewModel(OrderPromotionMappingViewModel orginal, IMapper mapper)
        {
            mapper.Map(orginal, this);
        }
    }
}
