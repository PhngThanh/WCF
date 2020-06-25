using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class SendModel
    {
        public int TerminalID { get; set; }
        public CustomerEditViewModel Customer { get; set; }
    }
}
