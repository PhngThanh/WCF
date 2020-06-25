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
    public class MembershipAPI : IAPI<MembershipVM>
    {
        private static string getByIdUrl = "api/membership/get-membership-id";
        private static string createdUrl = "api/membership/create-membership";
        private static string updateUrl = "api/membership/update-membership";
        private static string deleteUrl = "api/membership/delete-membership-id";

        public SkyConnectConfig Config { get; set; }
        public MembershipAPI(SkyConnectConfig config)
        {
            this.Config = config;
        }
        public BaseResponse<MembershipVM> GetById(int id, int partnerId)
        {
            // Declare data to request
            GetDeleteMembershipSchema dataRequest = new GetDeleteMembershipSchema()
            {
                MembershipId = id
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
                        var membershipResponse = JsonConvert.DeserializeObject<MembershipVM>(decrypted);
                        return new BaseResponse<MembershipVM>(content, membershipResponse, response.StatusCode);
                    }
                }
                return new BaseResponse<MembershipVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<MembershipVM> Create(MembershipVM viewModel, int partnerId)
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
                        return new BaseResponse<MembershipVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<MembershipVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<MembershipVM> Update(MembershipVM viewModel, int partnerId)
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
                        return new BaseResponse<MembershipVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<MembershipVM>(content, null, response.StatusCode);
            }
        }
        public BaseResponse<MembershipVM> Delete(int id, int partnerId)
        {
            // Declare data to request
            GetDeleteMembershipSchema dataRequest = new GetDeleteMembershipSchema()
            {
                MembershipId = id
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
                        return new BaseResponse<MembershipVM>(content, null, response.StatusCode);
                    }
                }
                return new BaseResponse<MembershipVM>(content, null, response.StatusCode);
            }
        }
        private class GetDeleteMembershipSchema
        {
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("phone")]
            public string Phone { get; set; }
            [JsonProperty("membership_id")]
            public int MembershipId { get; set; }
            [JsonProperty("membership_code")]
            public string MembershipCode { get; set; }
        }
    }
}
