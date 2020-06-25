using SkyConnect.POSLib.Domains;
using SkyConnect.POSLib.ResponseModels;
using SkyConnect.POSLib.Utils;
using SkyConnect.POSSimulator.Models;
using SkyConnect.POSSimulator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSSimulator
{
    public class Program
    {
        public static List<ProductModel> Products
        {
            get; set;
        }
        public static void ShowProducts()
        {
            
            if (Products == null)
            {
                Products = new List<ProductModel>()
                    {
                        new ProductModel{ ProductId = 1, ProductName = "Lime Tea", Price = 3000 },
                        new ProductModel{ ProductId = 2, ProductName = "Orange Tea", Price = 2000 },
                        new ProductModel{ ProductId = 3, ProductName = "Hot Lipton", Price = 1000 },
                        new ProductModel{ ProductId = 4, ProductName = "Earl Grey", Price = 3500 },
                        new ProductModel{ ProductId = 5, ProductName = "Iced Earl Grey", Price = 4000 },
                        new ProductModel{ ProductId = 6, ProductName = "Iced Lipton", Price = 3000 },
                        new ProductModel{ ProductId = 7, ProductName = "Raspberry Soda", Price = 8000 }
                    };
            }

            int count = 1;
            foreach (ProductModel product in Products)
            {
                Console.WriteLine($"{count}.Product Name : {product.ProductName}\tPrice: {product.Price}");
                count++;
            }
        }
        public static void Main(string[] args)
        {
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var a = RunAsync().Result;
        }

        private static async Task<bool> RunAsync()
        {
            #region Declare Menu's variable
            int choiceMenu = 0;
            var items = new List<string>() {
                "1. Thanh toán thông qua Merchant QR Code."
                , "2. Thanh toán bằng bằng mã thanh toán của khách hàng."
                , "3. Nạp tiền vào tài khoản thẻ hội viên."
                , "4. Thanh toán 1 hóa đơn 30k bằng thẻ hội viên."
            };
            Menu menu = new Menu() { Items = items };
            #endregion

            var config = SimulatorUtils.GetSkyConnectConfig();
            var pDomain = new SkyConnectPaymentDomain(config);
            Console.OutputEncoding = Encoding.UTF8;
            #region Main 
            do
            {
                try
                {
                    choiceMenu = menu.ChoiceItems();
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    switch (choiceMenu)
                    {
                        case 1:
                            FlowPaymentWithMerchantQRCode.Start();
                            break;
                        case 2:
                            FlowPaymentWithClientPaymentCode.Start();
                            break;
                        case 3:
                            FlowIncreaseMembershipCardInhouse.Start();
                            break;
                        case 4:
                            FlowPaymentMembershipCardInhouse.Start();
                            break;
                    }
                    Console.ResetColor();

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                    Console.ResetColor();
                }
            } while (choiceMenu != 0);
            #endregion
            return true;

        }

        public static void PrintInputPartnerId()
        {
            List<string> partnerStrings = new List<string>()
            {
                "0: Tự cung câp",
                "2: Momo",
                "3: GiftTalk"
            };
            Console.WriteLine("Lựa chọn id của Đối tác thực hiện.\n");
            foreach (var partner in partnerStrings)
            {
                Console.WriteLine(partner);
            }
            Console.Write("Nhập stt của đối tác: ");
        }

    

    }
}
