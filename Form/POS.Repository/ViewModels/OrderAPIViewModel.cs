using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ViewModels
{
    public partial class OrderAPIViewModel : OrderViewModel
    {
        //public List<PaymentEditViewModel> PaymentEditViewModels { get; set; }

        public List<OrderDetailEditViewModel> OrderDetailViewModels { get; set; }
        public OrderAPIViewModel(OrderViewModel orginal, IMapper mapper)
        {
            mapper.Map(orginal, this);
        }
        public OrderAPIViewModel()
        {

        }
    }

}
