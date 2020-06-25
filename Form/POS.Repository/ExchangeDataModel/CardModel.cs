using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class CardModel
    {
        public string token { get; set; }
        public int terminalId { get; set; }
        public string membershipCardCode { get; set; }

    }
}
