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
    public class FlowPaymentWithClientPaymentCode
    {

        public static OrderVM TestOrder
        {
            get; set;
        }
        private static void InputOrderCost(OrderVM orderVM)
        {
            Console.Write("Nhập số tiền bạn muốn thanh toán: ");
            var cost = double.Parse(Console.ReadLine());
            orderVM.FinalAmount = cost;
            orderVM.TotalAmount = cost;
        }
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
            TestOrder = new OrderVM()
            {
                OrderCode = "rpmp-test-" + DateTime.UtcNow.AddHours(7).ToString("yyyyMMddHHmmssss"),
                //OrderCode = "TEST-13-AS-3tt5968",
                CheckInDate = DateTime.UtcNow.AddHours(7),
                TotalAmount = 10000,
                Discount = 0,
                FinalAmount = 10000,
                OrderStatus = (int)SkyConnectOrderStatusEnum.New,
                OrderType = (int)SkyConnectOrderTypeEnum.AtStore,
                CustomerID = 1
            };


            var config = SimulatorUtils.GetSkyConnectConfig();
            var pDomain = new SkyConnectPaymentDomain(config);

            Console.ForegroundColor = ConsoleColor.Cyan;
            InputOrderCost(TestOrder);
            PrintOrder();
            Console.WriteLine("*************** Tạo mã cho khách hàng thanh toán ***************");
            Console.WriteLine("Mời bạn nhập ID của đối tác");
            var partner = SimulatorUtils.PrintInputPartnerId();
            Console.Write("Mời bạn nhập mã thanh toán: ");

            // Cập nhật paymentCode vào hóa đơn ( Quan trọng)
            var paymentCode = Console.ReadLine();
            TestOrder.PaymentCode = paymentCode;
            var isPayment = SimulatorUtils.ChoiceYesNo("Chọn yes để kiểm tra xác nhận thanh toán " + TestOrder.OrderCode + ": ");
            if (isPayment)
            {
                var orderPartner = pDomain.ConfirmPayment(TestOrder, partner).Result;
                if (orderPartner != null)
                {

                    if (orderPartner.OrderStatus == (int)SkyConnectOrderStatusEnum.Finish)
                    {
                        Console.WriteLine("\nMã hóa đơn: {0}\nSố tiền: {1}\nTình trạng hóa đơn: {2}\n"
                        , orderPartner.OrderCode
                        , orderPartner.FinalAmount
                        , orderPartner.OrderStatus == (int)SkyConnectOrderStatusEnum.Finish ? "Đã thanh toán" : "Chưa thanh toán");

                        Console.WriteLine("\nChi tiết giao dịch:");
                        var count = 0;
                        foreach (var trans in orderPartner.ListTransaction)
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
                        Console.WriteLine("\nMã hóa đơn: {0}\nSố tiền: {1}\nTình trạng hóa đơn: {2}\n"
                           , orderPartner.OrderCode
                           , orderPartner.FinalAmount
                           , orderPartner.OrderStatus == (int)SkyConnectOrderStatusEnum.Processing ? "Đang được partner xử lý" : "Giao dịch kết thúc");
                        var isCheckAgain = SimulatorUtils.ChoiceYesNo("Nhấn yes để kiếm tra đơn hàng lần nữa: ");
                        if (isCheckAgain)
                        {
                            var orderPartnerAgain = pDomain.GetOrder(TestOrder.OrderCode, TestOrder.CheckInDate.Value, partner);

                            if (orderPartnerAgain != null)
                            {
                                Console.WriteLine("\nMã hóa đơn: {0}\nSố tiền: {1}\nTình trạng hóa đơn: {2}\n"
                                    , orderPartnerAgain.OrderCode
                                    , orderPartnerAgain.FinalAmount
                                    , orderPartnerAgain.OrderStatus == (int)SkyConnectOrderStatusEnum.Finish ? "Đã thanh toán" : "Chưa thanh toán");

                                Console.WriteLine("\nChi tiết giao dịch:");
                                var count = 0;
                                foreach (var trans in orderPartnerAgain.ListTransaction)
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

                        }
                    }

                }
                else
                {
                    var isCheckAgain = SimulatorUtils.ChoiceYesNo("Nhấn yes để kiếm tra đơn hàng: ");
                    if (isCheckAgain)
                    {
                        var orderPartnerAgain = pDomain.GetOrder(TestOrder.OrderCode, TestOrder.CheckInDate.Value, partner);

                        if (orderPartnerAgain != null)
                        {
                            Console.WriteLine("\nMã hóa đơn: {0}\nSố tiền: {1}\nTình trạng hóa đơn: {2}\n"
                                , orderPartnerAgain.OrderCode
                                , orderPartnerAgain.FinalAmount
                                , orderPartnerAgain.OrderStatus == (int)SkyConnectOrderStatusEnum.Finish ? "Đã thanh toán" : "Chưa thanh toán");

                            Console.WriteLine("\nChi tiết giao dịch:");
                            var count = 0;
                            foreach (var trans in orderPartnerAgain.ListTransaction)
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

                        Console.WriteLine("Đơn hàng của bạn chưa được thanh toán.");
                    }
                    Console.WriteLine("*************************************************************");
                }
            }
            else
            {
                Console.WriteLine("Quá trình kiểm tra kết thúc!");
                Console.WriteLine("*************************************************************");
            }

                Console.ResetColor();
            }

        }
    }
