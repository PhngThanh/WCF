using PrinterManager.PrinterModel;
using POS.Repository;
using POS.Repository.Entities.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using POS.Repository.PrinterHelper;
using System.Web.Script.Serialization;
using System.Runtime.InteropServices;

namespace PrinterManager
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        //const int SW_SHOW = 5;
        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            ISubscriber subscriber = RadisConnectorHelper.Connection.GetSubscriber();
            subscriber.Subscribe(RadisConnectorHelper.ReceiptChannel, (channel, message) =>
            {
                    //Chia các thể loại in theo channel, BillChannel sẽ chỉ in bills, KitchenChannel sẽ chỉ in các món khách order
                    //Những action trong này mặc định sẽ là in cho bills
                    //In tất cả bills trong queue
                    //Nếu được thì nên dùng transactions, 1 là in hoàn thành tất cả các bills 2 là vẫn còn tất cả bills chưa được in trong queue.
                    //Đang in được nửa cái bills mà mất điện thì sao nhờ?
                    string modelJson = null;
                while (!string.IsNullOrEmpty(modelJson = RadisConnectorHelper.ListRightPop(RadisConnectorHelper.ReceiptChannel)))
                {
                    POS.Repository.PrinterModel.OrderPrinterModel modelObject
                        = Newtonsoft.Json.JsonConvert.DeserializeObject<POS.Repository.PrinterModel.OrderPrinterModel>(modelJson);
                    PrinterManager.PrintManager.Printer.PrintBillsVersion2(modelObject);
                }
            });

            Console.ReadLine();
        }
    }
}
