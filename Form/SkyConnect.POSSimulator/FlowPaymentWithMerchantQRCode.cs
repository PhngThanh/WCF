
using SkyConnect.POSLib.Domains;
using SkyConnect.POSLib.ResponseModels;
using SkyConnect.POSLib.Utils;
using SkyConnect.POSSimulator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSSimulator
{
    public class FlowPaymentWithMerchantQRCode
    {
        
        private static OrderVM TestOrder = new OrderVM()
        {
            OrderCode = "passio-staging-" + DateTime.UtcNow.AddHours(7).ToString("yyyyMMddHHmmssss"),
            CheckInDate = DateTime.UtcNow.AddHours(7),
            TotalAmount = 50000,
            Discount = 0,
            FinalAmount = 50000,
            OrderStatus = 1,
            OrderType = (int)SkyConnectOrderStatusEnum.New,
            CustomerID = 1
        };
    
        public static void PrintOrder()
        {
            Console.WriteLine();
            Console.WriteLine("*************** Đơn hàng hiện tại ***************");
            Console.WriteLine("OrderCode: " + TestOrder.OrderCode);
            Console.WriteLine("Ngày tạo: " + TestOrder.CheckInDate);
            Console.WriteLine("Tổng tiền: " + TestOrder.FinalAmount);
            Console.WriteLine("Khách hàng: " + TestOrder.CustomerID);
            Console.WriteLine("**************************************************");
        }

        public static void Start()
        {
            var config = SimulatorUtils.GetSkyConnectConfig();
            var pDomain = new SkyConnectPaymentDomain(config);

            Console.ForegroundColor = ConsoleColor.Cyan;
            InputOrderCost(TestOrder);
            PrintOrder();
            Console.WriteLine("*************** Tạo mã cho khách hàng thanh toán ***************");
            Console.WriteLine("Mời bạn nhập ID của đối tác");
            var partner = SimulatorUtils.PrintInputPartnerId();
            var qrCodeData = pDomain.GetQRCode(TestOrder.OrderCode, TestOrder.CheckInDate.Value, TestOrder.FinalAmount, partner);
            QRCode.GenerateQR(300, 300, qrCodeData);
            
            Console.WriteLine("Mã thanh toán đã được tạo tại: " + QRCode.QRPath);
            var isPayment = SimulatorUtils.ChoiceYesNo("Khách hàng của bạn đã thanh toán qua MOMO chưa\nChọn yes để kiểm tra tình trạng đơn hàng: ");

            if(isPayment)
            {
                var orderMomo = pDomain.GetOrder(TestOrder.OrderCode, TestOrder.CheckInDate.Value, partner);
                if (orderMomo != null)
                {
                    Console.WriteLine("\nMã hóa đơn: {0}\nSố tiền: {1}\nTình trạng hóa đơn: {2}\n"
                        , orderMomo.OrderCode
                        , orderMomo.FinalAmount
                        , orderMomo.OrderStatus == (int)SkyConnectOrderStatusEnum.Finish? "Đã thanh toán" : "Chưa thanh toán");

                    Console.WriteLine("\nChi tiết giao dịch:");
                    var count = 0;
                    foreach (var trans in orderMomo.ListTransaction)
                    {
                        Console.WriteLine("Giao dịch {0}:\nMã giao dịch: {1}\nSố tiền: {2}\nTình trạng: {3}\nĐối tác: {4}\n"
                            , ++count
                            , trans.TransactionCode
                            , trans.Amount
                            , (SkyConnectTransactionStatusEnum)trans.Status
                            , (SkyConnectPartnerEnum)trans.PartnerId);
                    }
                }
                else
                {
                    Console.WriteLine("Đơn hàng của bạn chưa được thanh toán.");
                }
                Console.WriteLine("*************************************************************");
            }else
            {
                Console.WriteLine("Quá trình kiểm tra kết thúc!");
                Console.WriteLine("*************************************************************");
            }

            Console.ResetColor();
        }


        private static void InputOrderCost(OrderVM orderVM)
        {
            Console.Write("Nhập số tiền bạn muốn thanh toán: ");
            var cost = double.Parse(Console.ReadLine());
            orderVM.FinalAmount = cost;
            orderVM.TotalAmount = cost;
        }


    }
}
