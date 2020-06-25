using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using POS.Repository.Entities;

namespace POS.Repository.ViewModels
{
    public partial class PaymentEditViewModel : PaymentViewModel
    {
        public PaymentEditViewModel()
        {
        }

        public PaymentEditViewModel(OrderDetailViewModel orginal, IMapper mapper)
        {
            mapper.Map(orginal, this);
        }

        public OrderEditViewModel OrderEditViewModel { get; set; }
    }
}
