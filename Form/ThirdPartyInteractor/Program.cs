using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyInteractor.crypto;
using Newtonsoft.Json;
using ThirdPartyInteractor.Momo;

namespace ThirdPartyInteractor
{
    class Program
    {
        static String MOMO_CHECKTRANS_API = "https://payment.momo.vn:2348/api/proxy/get-trans";

        static void Main(string[] args)
        {
            var checkStatusRequest = new
            {
                requestId = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds).ToString(),
                reference = "02922",
                created = "2017-11-10"
                //message = "something"
            };

            //TestApi(checkStatusRequest);
            CallMomoService(checkStatusRequest).Wait();
            Console.Read();
        }

        static async Task CallMomoService(object checkStatusRequest)
        {
            String checkStatusReponse = await MomoService.callMomoService(MOMO_CHECKTRANS_API, JsonConvert.SerializeObject(checkStatusRequest));
            Console.WriteLine("[Decoded] Check Status Response:\n" + checkStatusReponse);
        }

        static async Task TestApi(object checkStatusRequest)
        {
            PGPHandler.Init("../../0xB57D6F87/0xB57D6F87-pub.asc", "../../0xB57D6F87/0xB57D6F87-sec.asc", "12345");
            MemoryStream ms = new MemoryStream();
            PGPHandler.GetInstance().EncryptAndSign(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(checkStatusRequest)), ms);
            String encryptedData = Encoding.UTF8.GetString(ms.ToArray());

            Console.WriteLine(encryptedData);

            MemoryStream desStream = new MemoryStream();
            PGPHandler.GetInstance().DecryptAndVerifySignature(Encoding.UTF8.GetBytes(encryptedData), desStream);

            String decryptedData = Encoding.UTF8.GetString(desStream.ToArray());

            Console.WriteLine(decryptedData);
        }
    }
}
