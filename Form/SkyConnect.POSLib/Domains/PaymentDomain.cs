using SkyConnect.POSLib.Domains.APIs;
using SkyConnect.POSLib.ResponseModels;
using SkyConnect.POSLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.Domains
{
    public  class SkyConnectPaymentDomain
    {
        public OrderAPI OrderAPI { get; }
        public CardAPI CardAPI { get; }
        public SkyConnectPaymentDomain(SkyConnectConfig config)
        {
            this.OrderAPI = new OrderAPI(config);
            this.CardAPI = new CardAPI(config);
        }

        public bool CheckCardAvailablePayment(CardVM card, OrderVM order)
        {
            if(card.Balance >= order.FinalAmount)
            {
                return true;
            }
            return false;
        }


        public CardVM GetCardDetail(string cardCode, int partnerId)
        {
            CardVM cardRequest = new CardVM()
            {
                Code = cardCode
            };

            var cardVM = CardAPI.GetByCode(cardRequest, partnerId);
            return cardVM.Data;
        }

        /// <summary>
        /// Get Payment information:
        /// Order + Transactions
        /// </summary>
        /// <param name="orderCode"></param>
        /// <param name="checkInDate"></param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public OrderVM GetPaymentInformation(string orderCode, DateTime orderCheckInDate, int partnerId)
        {
            var orderVM = new OrderVM()
            {
                OrderCode = orderCode,
                CheckInDate = orderCheckInDate
            };


            var order = OrderAPI.GetByCode(orderVM, partnerId);
            return order.Data;
        }

        /// <summary>
        /// Get QRCode Inhouse or Partners
        /// </summary>
        /// <param name="orderCode">orderCode or Bill code</param>
        /// <param name="orderCheckInDate">CheckInDate of Bill</param>
        /// <param name="amount">Amount</param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public string GetQRCode(string orderCode, DateTime orderCheckInDate, double amount, int partnerId)
        {
            var orderVM = new OrderVM()
            {
                OrderCode = orderCode,
                CheckInDate = orderCheckInDate,
                FinalAmount = amount
            };
            var response = OrderAPI.GetOrderQRCode(orderVM, partnerId);
            if (response.Success == true)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task<OrderVM> ConfirmPayment(OrderVM order, int partnerId)
        {
            var orderVM = await OrderAPI.Create(order, partnerId);
            return orderVM.Data;
        }

        public OrderVM GetOrder(string orderCode, DateTime orderCheckInDate, int partnerId)
        {
            var orderVM = new OrderVM()
            {
                OrderCode = orderCode,
                CheckInDate = orderCheckInDate
            };


            var order = OrderAPI.GetByCode(orderVM, partnerId);
            return order.Data;
        }


    }
}
