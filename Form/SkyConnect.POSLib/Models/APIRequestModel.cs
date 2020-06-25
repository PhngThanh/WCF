using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.Models
{
    public class APIRequestModel
    {
        [JsonProperty("store_id")]
        public int StoreId { get; set; }
        [JsonProperty("partner_id")]
        public int PartnerId { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
