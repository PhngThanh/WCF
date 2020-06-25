using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ExchangeData.Model
{
    public class AccountModel
    {
        public string AccountId { get; set; }
        public string AccountPassword { get; set; }
        public string StaffName { get; set; }
        public string Role { get; set; }
        public bool IsUsed { get; set; }
        public string Token { get; set; }
        public int StoreId { get; set; }
    }
}
