using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SkyConnect.POSLib.Models;
using SkyConnect.POSLib.ResponseModels;
using SkyConnect.POSLib.Security;
using SkyConnect.POSLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.Domains.APIs
{
    public class CustomerAPI : IAPI<CustomerVM>
    {
        private static string getByIdUrl = "api/customer/get-customer-id";
        private static string createdUrl = "api/customer/create-customer";
        private static string updateUrl = "api/customer/update-customer";
        private static string deleteUrl = "api/customer/delete-customer-id";

        public SkyConnectConfig Config { get; set; }
        public CustomerAPI(SkyConnectConfig config)
        {
            this.Config = config;
        }
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public BaseResponse<CustomerVM> GetById(int id, int partnerId)
        {
            // Declare data to request
            GetDeleteCustomerSchema dataRequest = new GetDeleteCustomerSchema()
            {
                CustomerId = id
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
                        var customerResponse = JsonConvert.DeserializeObject<CustomerVM>(decrypted);
                        return new BaseResponse<CustomerVM>(content, customerResponse, response.StatusCode);
                    }
                }
                return new BaseResponse<CustomerVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<CustomerVM> Create(CustomerVM viewModel, int partnerId)
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
                        return new BaseResponse<CustomerVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<CustomerVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<CustomerVM> Update(CustomerVM viewModel, int partnerId)
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
                        return new BaseResponse<CustomerVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<CustomerVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<CustomerVM> Delete(int id, int partnerId)
        {
            // Declare data to request
            GetDeleteCustomerSchema dataRequest = new GetDeleteCustomerSchema()
            {
                CustomerId = id
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
                        return new BaseResponse<CustomerVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<CustomerVM>(content, null, response.StatusCode);
            }
        }
        private class GetDeleteCustomerSchema
        {
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("phone")]
            public string Phone { get; set; }
            [JsonProperty("customer_id")]
            public int CustomerId { get; set; }
            [JsonProperty("customer_code")]
            public string CustomerCode { get; set; }
        }
    }
}
