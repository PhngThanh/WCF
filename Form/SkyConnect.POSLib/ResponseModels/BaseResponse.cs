using Newtonsoft.Json;
using SkyConnect.POSLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.ResponseModels
{
    public class BaseResponse<T> where T : class
    {
        [JsonProperty("result-code")]
        public int ResultCode { get; set; }
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }

        public BaseResponse(APIResponseModel content, T data, HttpStatusCode status_code)
        {
            Success = content.Success;
            Message = content.Message;
            StatusCode = (int)status_code;
            Data = data;
        }
        public BaseResponse(APIResponseModel content, HttpStatusCode status_code)
        {
            Success = content.Success;
            Message = content.Message;
            StatusCode = (int)status_code;
        }
    }
}
