using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.Utils
{
    public class SkyConnectConfig
    {
        [JsonProperty("store_id")]
        public int StoreId { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("pgp_public_key")]
        public string PGPPublicKey { get; set; }
        [JsonProperty("des_key")]
        public string DesKey { get; set; }
        [JsonProperty("des_iv")]
        public string DesIV { get; set; }
        [JsonProperty("api_url")]
        public string ServerUri { get; set; }
    }

}
