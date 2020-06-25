using SkyConnect.POSLib.Domains.APIs;
using SkyConnect.POSLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib
{
    public class SkyConnect
    {
        public CustomerAPI CustomerApi { get; }
        public MembershipAPI MembershipApi { get; }
        public CardAPI CardApi { get; }
        public AccountAPI AccountApi { get; }
        public SkyConnect(SkyConnectConfig config)
        {
            this.CustomerApi = new CustomerAPI(config);
            this.MembershipApi = new MembershipAPI(config);
            this.CardApi = new CardAPI(config);
            this.AccountApi = new AccountAPI(config);
        }
    }
}
