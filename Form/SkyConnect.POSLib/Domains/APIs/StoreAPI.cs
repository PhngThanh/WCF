using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SkyConnect.POSLib.Models;
using SkyConnect.POSLib.ResponseModels;
using SkyConnect.POSLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SkyConnect.POSLib.Domains.APIs
{
    public class StoreAPI
    {
        private static string getStoreConfigByCodeUrl = "api/device/get-device-by-code";
        private static string updateConfig = "api/device/put-device-by-code-and-config";
        public SkyConnectConfig Config { get; set; }
        public StoreAPI(SkyConnectConfig config)
        {
            this.Config = config;
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public async Task<BaseResponse<string>> getStoreConfigByCode(string code)
        {
            // Request to DB
            using (var client = new HttpClient())
            {
                // Update Http Client to Json and Authorization
                SkyConnectUtils.UpdateHttpClient(client, Config);
                var path = getStoreConfigByCodeUrl + "/" + code.Replace("\r\n","");
                // Request and receive response
                HttpResponseMessage response = client.GetAsync(path).Result;
                var content = await response.Content.ReadAsAsync<JObject>();
                var success = content.GetValue("success").Value<Boolean>();
                var data = string.Empty;
                if (success)
                {
                    data = content.GetValue("data").SelectToken("Config").Value<string>();
                };
                Models.APIResponseModel apiResponse;
                apiResponse = new Models.APIResponseModel()
                {
                    Success = success,
                    Message = content.GetValue("Error").Value<string>()

                };
                // update config
                var currentDir = Environment.CurrentDirectory;
                var pathStoreInfo = currentDir + @"\Configuration\storeInfo.json";
                string config =System.IO.File.ReadAllText(pathStoreInfo);
                var json = new JObject();
                json.Add("config", config);
                json.Add("code", code.Replace("\r\n", ""));
                string jsonText = json.ToString();
                var httpContent = new StringContent(jsonText);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage response1 = client.PostAsync(updateConfig, httpContent).Result;
                //
                if (response.IsSuccessStatusCode)
                {
                    if (data != string.Empty)
                    {
                        return new BaseResponse<string>(apiResponse, data, response.StatusCode);
                    }
                }
                // Convert to Base Response and Return
                return new BaseResponse<string>(apiResponse, response.StatusCode);
            }
        }


    }
}
