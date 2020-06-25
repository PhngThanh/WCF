using Newtonsoft.Json;
using SkyConnect.POSLib.Models;
using SkyConnect.POSLib.ResponseModels;
using SkyConnect.POSLib.Security;
using SkyConnect.POSLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.Domains.APIs
{
    public class AccountAPI : IAPI<AccountVM>
    {
        private static string getByIdUrl = "api/account/get-account-id";
        private static string createdUrl = "api/account/create-account";
        private static string updateUrl = "api/account/update-account";
        private static string deleteUrl = "api/account/delete-account-id";

        public SkyConnectConfig Config { get; set; }
        public AccountAPI(SkyConnectConfig config)
        {
            this.Config = config;
        }
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public BaseResponse<AccountVM> GetById(int id, int partnerId)
        {
            // Declare data to request
            GetDeleteAccountSchema dataRequest = new GetDeleteAccountSchema()
            {
                AccountId = id
            };

            // Request to DB
            using (var client = new HttpClient())
            {
                // Update Http Client to Json and Authorization
                SkyConnectUtils.UpdateHttpClient(client, Config);

                //Get key and IV of TripldeDES to encrypt
                var brandKey = Config.DesKey;
                var brandIV = Config.DesIV;

                //Encrypt using TripleDes
                string encryptData = TripleDesHelper.EncryptFromString(JsonConvert.SerializeObject(dataRequest), brandKey, brandIV);

                // Create request object
                var request = new
                {
                    data = encryptData,
                    partner_id = partnerId,
                    store_id = Config.StoreId
                };

                // Request and receive response
                HttpResponseMessage response = client.PostAsJsonAsync(getByIdUrl, request).Result;
                var content = response.Content.ReadAsAsync<APIResponseModel>().Result;
                if (response.IsSuccessStatusCode)
                {
                    if (content != null)
                    {
                        // Decrypt data responsed
                        var decrypted = TripleDesHelper.DecryptFromString(content.Data, Config.DesKey, Config.DesIV);
                        var accountResponse = JsonConvert.DeserializeObject<AccountVM>(decrypted);
                        return new BaseResponse<AccountVM>(content, accountResponse, response.StatusCode);
                    }
                }
                return new BaseResponse<AccountVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<AccountVM> Create(AccountVM viewModel, int partnerId)
        {

            // Request to DB
            using (var client = new HttpClient())
            {
                // Update Http Client to Json and Authorization
                SkyConnectUtils.UpdateHttpClient(client, Config);

                //Get key and IV of TripldeDES to encrypt
                var brandKey = Config.DesKey;
                var brandIV = Config.DesIV;

                //Encrypt using TripleDes
                string encryptData = TripleDesHelper.EncryptFromString(JsonConvert.SerializeObject(viewModel), brandKey, brandIV);

                // Create request object
                var request = new APIRequestModel()
                {
                    Data = encryptData,
                    PartnerId = partnerId,
                    StoreId = Config.StoreId
                };

                // Request and receive response
                HttpResponseMessage response = client.PostAsJsonAsync(createdUrl, request).Result;
                var content = response.Content.ReadAsAsync<APIResponseModel>().Result;
                if (response.IsSuccessStatusCode)
                {
                    if (content != null)
                    {
                        return new BaseResponse<AccountVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<AccountVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<AccountVM> Update(AccountVM viewModel, int partnerId)
        {
            // Request to DB
            using (var client = new HttpClient())
            {
                // Update Http Client to Json and Authorization
                SkyConnectUtils.UpdateHttpClient(client, Config);

                //Get key and IV of TripldeDES to encrypt
                var brandKey = Config.DesKey;
                var brandIV = Config.DesIV;

                //Encrypt using TripleDes
                string encryptData = TripleDesHelper.EncryptFromString(JsonConvert.SerializeObject(viewModel), brandKey, brandIV);

                // Create request object
                var request = new APIRequestModel()
                {
                    Data = encryptData,
                    PartnerId = partnerId,
                    StoreId = Config.StoreId
                };

                // Request and receive response
                HttpResponseMessage response = client.PostAsJsonAsync(updateUrl, request).Result;
                var content = response.Content.ReadAsAsync<APIResponseModel>().Result;
                if (response.IsSuccessStatusCode)
                {
                    if (content != null)
                    {
                        return new BaseResponse<AccountVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<AccountVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<AccountVM> Delete(int id, int partnerId)
        {
            // Declare data to request
            GetDeleteAccountSchema dataRequest = new GetDeleteAccountSchema()
            {
                AccountId = id
            };


            // Request to DB
            using (var client = new HttpClient())
            {
                // Update Http Client to Json and Authorization
                SkyConnectUtils.UpdateHttpClient(client, Config);

                //Get key and IV of TripldeDES to encrypt
                var brandKey = Config.DesKey;
                var brandIV = Config.DesIV;

                //Encrypt using TripleDes
                string encryptData = TripleDesHelper.EncryptFromString(JsonConvert.SerializeObject(dataRequest), brandKey, brandIV);

                // Create request object
                var request = new APIRequestModel()
                {
                    Data = encryptData,
                    PartnerId = partnerId,
                    StoreId = Config.StoreId
                };

                // Request and receive response
                HttpResponseMessage response = client.PostAsJsonAsync(updateUrl, request).Result;
                var content = response.Content.ReadAsAsync<APIResponseModel>().Result;
                if (response.IsSuccessStatusCode)
                {
                    if (content != null)
                    {
                        return new BaseResponse<AccountVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<AccountVM>(content, null, response.StatusCode);
            }
        }
        private class GetDeleteAccountSchema
        {
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("phone")]
            public string Phone { get; set; }
            [JsonProperty("account_id")]
            public int AccountId { get; set; }
            [JsonProperty("account_code")]
            public string AccountCode { get; set; }
        }
    }
}
