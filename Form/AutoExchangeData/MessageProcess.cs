using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoExchangeData;

namespace AutoExchangeData
{
    public class MessageProcess
    {
        public void ProcessMessage(MessageSend message)
        {
            //Do nothing 
            //Sau khi lấy về do something: (Dùng console show)
            if (message.NotifyType == (int)NotifyMessageType.OrderChange)
            {
                //Do something with order
                DataExchanger.GetOrder(message.RentId).Wait();
            }
            if (message.NotifyType == (int)NotifyMessageType.AccountChange)
            {
                //Do something with accout
            }
            if (message.NotifyType == (int)NotifyMessageType.ProductChange)
            {
                //Do something with product
            }
            if (message.NotifyType == (int)NotifyMessageType.CategoryChange)
            {
                //Do something with Category
            }

        }
    }
}
