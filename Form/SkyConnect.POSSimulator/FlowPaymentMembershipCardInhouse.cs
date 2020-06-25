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
    public class FlowPaymentMembershipCardInhouse
    {
        public static OrderVM TestOrder
        {
            get; set;
        }
        public static void PrintOrder()
        {
            Console.WriteLine();
            Console.WriteLine("*************** Đơn hàng hiện tại ***************");
            Console.WriteLine("OrderCode: " + TestOrder.OrderCode);
            Console.WriteLine("Ngày tạo: " + TestOrder.CheckInDate);
            Console.WriteLine("Tổng tiền: " + TestOrder.FinalAmount);
            Console.WriteLine("Khách hàng: " + TestOrder.CustomerID);
            Console.WriteLine();
            if (TestOrder.ListTransaction != null)
            {
                Console.WriteLine("Chi tiết giao dịch:");
                var count = 0;
                foreach (var trans in TestOrder.ListTransaction)
                {
                    Console.WriteLine("Giao dịch {0}:\nSố tiền: {1}\nTài khoản: {2}\nMã thẻ: {3}\n"
                        , trans.TransactionCode
                        , trans.Amount
                        , trans.AccountCode
                        , trans.CardCode);
                }
                Console.WriteLine();
            }
            Console.WriteLine("**************************************************");
        }

        public static void Start()
        {
            var config = SimulatorUtils.GetSkyConnectConfig();
            var pDomain = new SkyConnectPaymentDomain(config);

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("*************** Thanh toán thông qua thẻ thành viên ***************");
            // Step 1: Cashier tạo Order theo yêu cầu của khách hàng
            var time = DateTime.UtcNow.AddHours(7);
            TestOrder = new OrderVM()
            {
                OrderCode = string.Format("order-inhouse-{0}", time.ToString("yyMMddHHmmssss")),
                CheckInDate = time
            };
            TestOrder.FinalAmount = 200;
            TestOrder.Discount = 0;
            TestOrder.TotalAmount = 200;
            PrintOrder();
            // Step 2: Cashier nhập mã thẻ của khách hàng vào.
            Console.Write("\nNhập mã thẻ của khách hàng: ");
            var cardCode = Console.ReadLine();
            var partner = SimulatorUtils.PrintInputPartnerId();

            // Step 3: System trả về thông tin thẻ
            var cardDetail = pDomain.GetCardDetail(cardCode, partner);
            cardDetail.PrintData();

            // Step 4: System check Available Card to Payment
            var isAvailable = pDomain.CheckCardAvailablePayment(cardDetail, TestOrder);
            if (isAvailable)
            {
                // Step 5: Cashier chọn Yes để thanh toán.
                var isPayment = SimulatorUtils.ChoiceYesNo("Bạn có muốn thanh toán hóa đơn cho thẻ này, yes/no: ");

                // Step 6: DLL tạo Order và các Transaction.
                if (isPayment)
                {
                    TestOrder.CustomerID = cardDetail.CustomerId;
                    TestOrder.ListTransaction = new List<TransactionVM>()
                    {
                        new TransactionVM()
                        {
                            AccountCode = cardDetail.Accounts.FirstOrDefault(acc => acc.Type == (int)SkyConnectAccountTypeEnum.CreditAccount).AccountCode,
                            CardCode = cardDetail.Code,
                            IsIncreaseTransaction = false,
                            Amount =(decimal)TestOrder.FinalAmount,
                        }
                    };
                    TestOrder.CardCode = cardCode;

                    var createOrderResult = pDomain.ConfirmPayment(TestOrder, partner).Result;
                    TestOrder = createOrderResult;
                    PrintOrder();
                    if (createOrderResult != null)
                    {
                        Console.WriteLine("Hóa đơn đã được thanh toán cho thẻ của {0}", cardDetail.CustomerName);
                    }
                    else
                    {
                        Console.WriteLine("Thanh toán hóa đơn thất bại.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Thẻ của khách hàng hiện tại không đủ để thanh toán.");
            }
            Console.ResetColor();
        }
    }
}
