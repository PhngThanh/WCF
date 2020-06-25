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
    public class CardAPI : IAPI<CardVM>
    {
        private static string getByIdUrl = "api/card/get-card-id";
        private static string getByCodeUrl = "api/card/get-card-code";
        private static string createdUrl = "api/card/create-card";
        private static string updateUrl = "api/card/update-card";
        private static string deleteUrl = "api/card/delete-card-id";

        public SkyConnectConfig Config { get; set; }
        public CardAPI(SkyConnectConfig config)
        {
            this.Config = config;
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public BaseResponse<CardVM> GetByCode(CardVM card, int partnerId)
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
                string encryptData = TripleDesHelper.EncryptFromString(JsonConvert.SerializeObject(card), brandKey, brandIV);

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
                        var cardResponse = JsonConvert.DeserializeObject<CardVM>(decrypted);
                        return new BaseResponse<CardVM>(content, cardResponse, response.StatusCode);
                    }
                }
                return new BaseResponse<CardVM>(content, null, response.StatusCode);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public BaseResponse<CardVM> GetById(int id, int partnerId)
        {
            // Declare data to request
            GetDeleteCardSchema dataRequest = new GetDeleteCardSchema()
            {
                CardId = id
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
                        var cardResponse = JsonConvert.DeserializeObject<CardVM>(decrypted);
                        return new BaseResponse<CardVM>(content, cardResponse, response.StatusCode);
                    }
                }
                return new BaseResponse<CardVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<CardVM> Create(CardVM viewModel, int partnerId)
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
                        return new BaseResponse<CardVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<CardVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<CardVM> Update(CardVM viewModel, int partnerId)
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
                        return new BaseResponse<CardVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<CardVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<CardVM> Delete(int id, int partnerId)
        {
            // Declare data to request
            GetDeleteCardSchema dataRequest = new GetDeleteCardSchema()
            {
                CardId = id
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
                        return new BaseResponse<CardVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<CardVM>(content, null, response.StatusCode);
            }
        }
        private class GetDeleteCardSchema
        {
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("phone")]
            public string Phone { get; set; }
            [JsonProperty("card_id")]
            public int CardId { get; set; }
            [JsonProperty("card_code")]
            public string CardCode { get; set; }
        }
    }
}
