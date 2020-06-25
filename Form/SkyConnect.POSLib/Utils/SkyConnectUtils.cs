using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.Utils
{
    public class SkyConnectUtils
    {
        public static SkyConnectConfig ParseStringToSkyConnectConfig(string json)
        {
            return JsonConvert.DeserializeObject<SkyConnectConfig>(json);
        }

        internal static void UpdateHttpClient(HttpClient client, SkyConnectConfig config)
        {
            client.BaseAddress = new Uri(config.ServerUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", config.Token));
        }
    }
}
