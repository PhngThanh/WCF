using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class MessageReturnModel
    {
        public string message { get; set; }
        public bool success { get; set; }
    }
}
