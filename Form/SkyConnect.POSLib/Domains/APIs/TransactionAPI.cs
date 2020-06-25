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
    public class TransactionAPI : IAPI<TransactionVM>
    {
        private static string getByIdUrl = "api/transaction/get-transaction-id";
        private static string createdUrl = "api/transaction/create-transaction";
        private static string updateUrl = "api/transaction/update-transaction";
        private static string deleteUrl = "api/transaction/delete-transaction-id";

        public SkyConnectConfig Config { get; set; }
        public TransactionAPI(SkyConnectConfig config)
        {
            this.Config = config;
        }

        #region Base Functions
        public BaseResponse<TransactionVM> GetById(int id, int partnerId)
        {
            // Declare data to request
            GetDeleteTransactionSchema dataRequest = new GetDeleteTransactionSchema()
            {
                TransactionId = id
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
                        var transactionResponse = JsonConvert.DeserializeObject<TransactionVM>(decrypted);
                        return new BaseResponse<TransactionVM>(content, transactionResponse, response.StatusCode);
                    }
                }
                return new BaseResponse<TransactionVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<TransactionVM> Create(TransactionVM viewModel, int partnerId)
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
                        return new BaseResponse<TransactionVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<TransactionVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<TransactionVM> Update(TransactionVM viewModel, int partnerId)
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
                        return new BaseResponse<TransactionVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<TransactionVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<TransactionVM> Delete(int id, int partnerId)
        {
            // Declare data to request
            GetDeleteTransactionSchema dataRequest = new GetDeleteTransactionSchema()
            {
                TransactionId = id
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
                HttpResponseMessage response = client.PostAsJsonAsync(deleteUrl, request).Result;
                var content = response.Content.ReadAsAsync<APIResponseModel>().Result;
                if (response.IsSuccessStatusCode)
                {
                    if (content != null)
                    {
                        return new BaseResponse<TransactionVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<TransactionVM>(content, null, response.StatusCode);
            }
        }
        #endregion

        #region Advance functions
        public BaseResponse<TransactionVM> CreateListTransaction(IEnumerable<TransactionVM> viewModel, int partnerId)
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
                        return new BaseResponse<TransactionVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<TransactionVM>(content, null, response.StatusCode);
            }
        }
        #endregion
        private class GetDeleteTransactionSchema
        {
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("phone")]
            public string Phone { get; set; }
            [JsonProperty("transaction_id")]
            public int TransactionId { get; set; }

        }
    }
}
