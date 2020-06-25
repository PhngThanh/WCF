
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
    public static class FlowIncreaseMembershipCardInhouse
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
                        , ++count
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

            Console.WriteLine("*************** Nạp tiền thẻ thành viên ***************");
            // Step 1: Cashier nhập số tiền muốn nạp
            Console.Write("Nhập số tiền muốn nạp vào thẻ: ");
            var money = float.Parse(Console.ReadLine());
            var time = DateTime.UtcNow.AddHours(7);
            TestOrder = new OrderVM()
            {
                OrderCode = string.Format("order-inhouse-{0}", time.ToString("yyMMddHHmmssss")),
                CheckInDate = time
            };
            TestOrder.FinalAmount = money;
            TestOrder.Discount = 0;
            TestOrder.TotalAmount = money;
            // Step 2: Cashier nhập mã thẻ của khách hàng vào.
            var partner = SimulatorUtils.PrintInputPartnerId();
            Console.Write("Nhập mã thẻ của khách hàng: ");
            var cardCode = Console.ReadLine();

            // Step 3: System trả về thông tin thẻ
            var cardDetail = pDomain.GetCardDetail(cardCode, partner);
            cardDetail.PrintData();

            // Step 3: Cashier chọn Yes để thanh toán.
            var isPayment = SimulatorUtils.ChoiceYesNo("Bạn có muốn nạp tiền vào thẻ này không, yes/no: ");

            // Step 4: DLL tạo Order và các Transaction.
            if (isPayment)
            {
                TestOrder.CustomerID = cardDetail.CustomerId;
                TestOrder.ListTransaction = new List<TransactionVM>()
                {
                    new TransactionVM()
                    {
                        AccountCode = cardDetail.Accounts.FirstOrDefault(acc => acc.Type == (int)SkyConnectAccountTypeEnum.CreditAccount).AccountCode,
                        CardCode = cardDetail.Code,
                        IsIncreaseTransaction = true,
                        Amount =(decimal)money,

                    }
                };

                var createOrderResult = pDomain.ConfirmPayment(TestOrder, partner);
                PrintOrder();
                if(createOrderResult != null)
                {
                    Console.WriteLine("Thẻ hội viên đã được nạp tiền!");
                }
                else
                {
                    Console.WriteLine("Nạp tiền thẻ thành viên thất bại!");
                }

            }

            Console.ResetColor();
        }



    }
}
