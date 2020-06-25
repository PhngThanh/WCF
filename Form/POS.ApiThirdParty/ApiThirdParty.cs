using System;
using System.Net;

namespace POS.ApiThirdPartyDLL
{

    public class ApiThirdParty
    {
        //static StoreInfo storeInfo = new StoreInfo();


        #region SmileCard
        //        public static List<string> CreateInput(string barCode, int finalAmount, DateTime checkInDate, string orderCode)
        //        {
        //            List<string> input = new List<string>();
        //            string input61 = finalAmount.ToString();
        //            string string0 = "";
        //            for (int i = input61.Length; i < 12; i++)
        //            {

        //                string0 += "0";
        //                if (i == 11)
        //                {
        //                    input61 = string0 + input61;
        //                }

        //            }
        //            //0:
        //            //7038010000C0008C
        //            input.Add("0:" + "7038010000C0008C");
        //            //2:
        //            //6019 + 530050000092 
        //            //Card no. Chú ý: khi scan barcode vào, thêm 6019 vào trước 12 số nhận được trên thẻ VUS
        //            input.Add("2:" + "6019" + barCode);
        //            //3:
        //            //000000 
        //            //Processing code (config)
        //            input.Add("3:" + storeInfo.ProcessingCode);
        //            //4:
        //            //10000000  
        //            //Amount
        //            input.Add("4:" + finalAmount.ToString());
        //            //11:
        //            //225
        //            input.Add("11:" + "225");
        //            //12:
        //            //133209
        //            //Time (hhmmss)
        //            input.Add("12:" + checkInDate.ToString("hhmmss"));
        //            //13:
        //            //1112
        //            //Date (mmdd)
        //            input.Add("13:" + checkInDate.ToString("MMdd"));
        //            //24:
        //            //559
        //            input.Add("24:" + "559");
        //            //41:
        //            //00000001
        //            //Terminal ID (config)
        //            input.Add("41:" + storeInfo.TerminalId);
        //            //42:
        //            //000000000000030 
        //            //Merchant ID (config)
        //            input.Add("42:" + storeInfo.MerchantId);
        //            //57:
        //            //0000
        //            //Staff ID (config)
        //            input.Add("57:" + storeInfo.StaffId);
        //            //61:
        //            //000000100000 = 10.0 = 0.5#
        //            //Amount = Discount percentage (config) = Saving (config)
        //            input.Add("61:" + input61 + "=" + storeInfo.DiscountPercent + "=" + storeInfo.Saving + "#");
        //            //62:
        //            //000000000001
        //            //Bill number
        //            input.Add("62:" + orderCode);

        //            int lenghtBarcode = barCode.Length;

        //            barCode = barCode.Remove(lenghtBarcode - 1);


        //            string xmlTest =
        //           @"<?xml version=""1.0"" encoding=""utf-8""?>
        //           <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
        //            <soap:Body>
        //            <excuteTerminalQuery xmlns=""http://tempuri.org/"">
        //             <input>"
        //             + "<string>0:7038010000C0008C</string>"
        //              //+ "<string>2:6019530094511435</string>"
        //              + "<string>2:6019" + barCode + "</string>"
        //              + "<string>3:" + storeInfo.ProcessingCode + "</string>"
        //              + "<string>4:" + finalAmount.ToString() + "</string>"
        //              + "<string>11:225</string>"
        //              + "<string>12:" + checkInDate.ToString("hhmmss") + "</string>"
        //              + "<string>13:" + checkInDate.ToString("MMdd") + "</string>"
        //        + "<string>24:559</string>"
        //              + "<string>41:" + storeInfo.TerminalId + "</string>"
        //              + "<string>42:" + storeInfo.MerchantId + "</string>"
        //              + "<string>57:" + storeInfo.StaffId + "</string>"
        //        + "<string>61:" + input61 + " = " + storeInfo.DiscountPercent + "=" + storeInfo.Saving + "#" + "</string>"
        //              //+ "<string>61:6019530050000092= " + storeInfo.DiscountPercent + "=" + storeInfo.Saving + "#" + "</string>"
        //              + "<string>62:" + orderCode + "</string>"
        //      + "</input>"
        //   + " </excuteTerminalQuery>"
        //  + "</soap:Body>"
        //+ "</soap:Envelope>";

        //            HttpWebRequest request = CreateWebRequest();
        //            XmlDocument soapEnvelopeXml = new XmlDocument();
        //            soapEnvelopeXml.LoadXml(xmlTest);

        //            using (Stream stream = request.GetRequestStream())
        //            {
        //                soapEnvelopeXml.Save(stream);
        //            }
        //            using (WebResponse response = request.GetResponse())
        //            {
        //                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
        //                {
        //                    string soapResult = rd.ReadToEnd();
        //                    Console.WriteLine(soapResult);
        //                }
        //            }
        //            return input;
        //        }


        public static HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://rewards.smilescard.vn/phoenix/Phoenix.asmx?op=excuteTerminalQuery");
            //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://123.123");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
        #endregion

        #region Generate Pass Wifi

        public static string GenerateWifiPassForLocation(string locationId, DateTime? time)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(locationId))
            {
                int.TryParse(locationId, out id);
            }
            if (id == 0)
                return GenerateWifiPassword(time ?? DateTime.Now);
            else
                return GenerateWifiPassForLocation(id, time ?? DateTime.Now);
        }

        public static string GenerateWifiPassword(DateTime time)
        {
            string second = time.Second.ToString();
            string day = time.Day.ToString();
            string hour = time.Hour.ToString();
            string minute = time.Minute.ToString();

            string str = "1" + AddZero(hour) + AddZero(second) + AddZero(minute);
            string password = ((long.Parse(str) - 98765) / 2).ToString();
            return password;
        }

        public static string GenerateWifiPassForLocation(int locationId, DateTime time)
        {
            long pass = (long)(time - new DateTime(time.Year, 1, 1)).TotalMinutes;
            pass += locationId;
            var passText = pass.ToString();
            string reverse = "";
            for (int i = passText.Length - 1; i > -1; i--)
            {
                reverse += passText[i];
            }
            return reverse;
        }

        private static string AddZero(string x)
        {
            if (x.Length == 1)
            {
                x = "0" + x;
            }
            return x;
        }

        public static bool CheckWifiPasswordForLocation(string userPass, int locationId, int timeOutminute)
        {
            //Get value from user password
            string reverse = "";
            for (int i = userPass.Length - 1; i > -1; i--)
            {
                reverse += userPass[i];
            }
            long passValue = long.Parse(reverse) - locationId;//Total minutes from the begin of the year 

            //Get code from cur
            DateTime dt = UtcDateTimeNow();


            long currentMinute = (long)(dt - new DateTime(dt.Year, 1, 1)).TotalMinutes;
            //Get different minutes between the time to generate pass and the time to check password
            long deltaMinute = currentMinute - passValue;

            return (deltaMinute >= 0 && deltaMinute <= timeOutminute);

        }
        #endregion


        public static DateTime UtcDateTimeNow()
        {
            #region Get DateTime.Now
            //Get time UTC 
            DateTime utcNow = DateTime.UtcNow;

            //2.0
            //DateTime datetimeNow = utcNow;

            //Parse UTC to time SE Asia
            DateTime datetimeNow = TimeZoneInfo.ConvertTime(utcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
            #endregion

            return datetimeNow;
        }
    }
}
