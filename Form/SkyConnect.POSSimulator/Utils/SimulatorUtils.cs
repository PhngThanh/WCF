using Newtonsoft.Json;
using SkyConnect.POSLib.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSSimulator.Utils
{
    public class SimulatorUtils
    {
        public static string CONFIG_HOST_PATH = AppDomain.CurrentDomain.BaseDirectory + @"Configuration\StoreJson-Host.json";
        public static string CONFIG_LOCAL_PATH = AppDomain.CurrentDomain.BaseDirectory + @"Configuration\StoreJson-Local.json";

        public static SkyConnectConfig GetSkyConnectConfig()
        {
            if(ConfigurationManager.AppSettings["IsTest"].ToString().Equals("1"))
            {
                using(var stream = new StreamReader(CONFIG_LOCAL_PATH))
                {
                    return JsonConvert.DeserializeObject<SkyConnectConfig>(stream.ReadToEnd());
                }
            } else
            {
                using (var stream = new StreamReader(CONFIG_HOST_PATH))
                {
                    return JsonConvert.DeserializeObject<SkyConnectConfig>(stream.ReadToEnd());
                }
            }
        }

        public static bool ChoiceYesNo(string Question)
        {
            Console.Write(Question);
            var result = Console.ReadLine();
            if(result.Equals("y",StringComparison.OrdinalIgnoreCase) || result.Equals("yes", StringComparison.OrdinalIgnoreCase) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int PrintInputPartnerId()
        {
            List<string> partnerStrings = new List<string>()
            {
                "0: Tự cung câp",
                "2: Momo",
                "3: GiftTalk",
                "5: Zalo Pay",
                "7: Viettel Pay"
            };
            Console.WriteLine("Lựa chọn id của Đối tác thực hiện.\n");
            foreach (var partner in partnerStrings)
            {
                Console.WriteLine(partner);
            }
            Console.Write("Nhập stt của đối tác: ");
            return int.Parse(Console.ReadLine());
        }


    }
}
