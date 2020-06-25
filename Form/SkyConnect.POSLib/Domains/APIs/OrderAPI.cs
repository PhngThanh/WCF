using Newtonsoft.Json;
using SkyConnect.POSLib.Models;
using SkyConnect.POSLib.ResponseModels;
using SkyConnect.POSLib.Security;
using SkyConnect.POSLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.Domains.APIs
{
    public class OrderAPI
    {
        private static string getByIdUrl = "api/order/get-order-id";
        private static string getByCodeUrl = "api/order/get-order-code";
        private static string getOrderQRCode = "api/order/get-order-qrcode";
        private static string createdUrl = "api/order/create-order";
        private static string updateUrl = "api/order/update-order";
        private static string deleteUrl = "api/order/delete-order-id";

        public SkyConnectConfig Config { get; set; }
        public OrderAPI(SkyConnectConfig config)
        {
            this.Config = config;
        }
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public BaseResponse<OrderVM> GetById(OrderVM orderRequest, int partnerId)
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
                string encryptData = TripleDesHelper.EncryptFromString(JsonConvert.SerializeObject(orderRequest), brandKey, brandIV);

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
                        var orderResponse = JsonConvert.DeserializeObject<OrderVM>(decrypted);
                        return new BaseResponse<OrderVM>(content, orderResponse, response.StatusCode);
                    }
                }
                // Convert to Base Response and Return
                return new BaseResponse<OrderVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<OrderVM> GetByCode(OrderVM orderRequest, int partnerId)
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
                string encryptData = TripleDesHelper.EncryptFromString(JsonConvert.SerializeObject(orderRequest), brandKey, brandIV);
                // Create request object
                var request = new
                {
                    data = encryptData,
                    partner_id = partnerId,
                    store_id = Config.StoreId
                };

                // Request and receive response
                HttpResponseMessage response = client.PostAsJsonAsync(getByCodeUrl, request).Result;
                var content = response.Content.ReadAsAsync<APIResponseModel>().Result;
                if (response.IsSuccessStatusCode)
                {
                    if (content != null)
                    {
                        // Decrypt data responsed
                        var decrypted = TripleDesHelper.DecryptFromString(content.Data, Config.DesKey, Config.DesIV);
                        var orderResponse = JsonConvert.DeserializeObject<OrderVM>(decrypted);
                        return new BaseResponse<OrderVM>(content, orderResponse, response.StatusCode);
                    }
                }
                return new BaseResponse<OrderVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<string> GetOrderQRCode(OrderVM orderRequest, int partnerId)
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
                string encryptData = TripleDesHelper.EncryptFromString(JsonConvert.SerializeObject(orderRequest), brandKey, brandIV);

                // Create request object
                var request = new
                {
                    data = encryptData,
                    partner_id = partnerId,
                    store_id = Config.StoreId
                };

                // Request and receive response
                HttpResponseMessage response = client.PostAsJsonAsync(getOrderQRCode, request).Result;
                var content = response.Content.ReadAsAsync<APIResponseModel>().Result;
                if (response.IsSuccessStatusCode)
                {
                    if (content != null)
                    {
                        // Decrypt data responsed
                        //var decrypted = TripleDesHelper.DecryptFromString(content.Data, Config.DesKey, Config.DesIV);
                        //var orderResponse = JsonConvert.DeserializeObject<string>(decrypted);
                        return new BaseResponse<string>(content, content.Data, response.StatusCode);
                    }
                }
                return new BaseResponse<string>(content, content.Data, response.StatusCode);
            }
        }
        public async Task<BaseResponse<OrderVM>> Create(OrderVM viewModel, int partnerId)
        {
            ServicePointManager.ServerCertificateValidationCallback =
               delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
               {
                   return true;
               };
            // Request to DB
            using (var client = new HttpClient())
            {
                // Update Http Client to Json and Authorization
                SkyConnectUtils.UpdateHttpClient(client, Config);

                //Get key and IV of PGP to encrypt
                var publicKey = Config.PGPPublicKey;

                //Encrypt using TripleDes
                string encryptData = new PGPEncryptHelper(publicKey, JsonConvert.SerializeObject(viewModel)).GetEncryptedData();

                // Create request object
                var request = new APIRequestModel()
                {
                    Data = encryptData,
                    PartnerId = partnerId,
                    StoreId = Config.StoreId
                };

                // Request and receive response
                HttpResponseMessage response =  client.PostAsJsonAsync(createdUrl, request).Result;
                var content =  response.Content.ReadAsAsync<APIResponseModel>().Result;
                if (response.IsSuccessStatusCode)
                {
                    if (content != null)
                    {
                        var decryptedData = TripleDesHelper.DecryptFromString(content.Data, Config.DesKey, Config.DesIV);
                        var decryptedOrderVM = JsonConvert.DeserializeObject<OrderVM>(decryptedData);
                        return new BaseResponse<OrderVM>(content, decryptedOrderVM, response.StatusCode);
                    }
                }
                return new BaseResponse<OrderVM>(content, null, response.StatusCode);
            }


        }
        public BaseResponse<OrderVM> Update(OrderVM viewModel, int partnerId)
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
                        return new BaseResponse<OrderVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<OrderVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<OrderVM> Delete(OrderVM orderRequest, int partnerId)
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
                string encryptData = TripleDesHelper.EncryptFromString(JsonConvert.SerializeObject(orderRequest), brandKey, brandIV);

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
                        return new BaseResponse<OrderVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<OrderVM>(content, null, response.StatusCode);
            }
        }
    }
}

