using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyInteractor.crypto;

namespace ThirdPartyInteractor.Momo
{
    public class MomoService
    {
        private static readonly String MOMO_CHECKTRANS_API = "https://payment.momo.vn:19955/api/proxy/get-trans";
        private static readonly String MOMO_PUBLICKEY_PATH = Path.Combine(Environment.CurrentDirectory,@"./momo-pub.asc");
        private static readonly String PARTNER_CODE = "passio";
        private static readonly String PARTNER_PRIVATEKEY_PATH = Path.Combine(Environment.CurrentDirectory, @"./passio-sec.asc");
        private static readonly String PARTNET_PASSPHRASE = "zaQ@123";

        private static async Task<String> callPostMethod(String url, String data)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/pgp-encrypted"));
            request.Headers.Add("partner-code", PARTNER_CODE);

            var content = new StringContent(data);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/pgp-encrypted");
            request.Content = content;

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string reponseData = await response.Content.ReadAsStringAsync();
                return reponseData;
            }
            throw new Exception("Unable to send");
        }

        public static async Task<String> callMomoService(String url, string request)
        {
            try
            {
                try
                {
                    PGPHandler.Init(MOMO_PUBLICKEY_PATH, PARTNER_PRIVATEKEY_PATH, PARTNET_PASSPHRASE);
                }
                catch (Exception ex)
                {
                }
                MemoryStream ms = new MemoryStream();
                PGPHandler.GetInstance().EncryptAndSign(Encoding.UTF8.GetBytes(request), ms);
                String encryptedData = Encoding.UTF8.GetString(ms.ToArray());

                String responseStr = await callPostMethod(url, encryptedData);
                MemoryStream desStream = new MemoryStream();

                String decryptedData = PGPHandler.GetInstance().DecryptAndVerifySignature(Encoding.UTF8.GetBytes(responseStr), desStream);

                return decryptedData;
            }
            catch (Exception)
            {
                return null;
            }
            

        }
    }
}