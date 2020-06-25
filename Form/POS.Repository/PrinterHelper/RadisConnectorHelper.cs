using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.PrinterHelper
{
    public class RadisConnectorHelper
    {
        public const string ReceiptChannel = "ReceiptChannel";
        private static Lazy<ConnectionMultiplexer> lazyConnection;

        static RadisConnectorHelper()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost");
            });
        }

        public static ConnectionMultiplexer Connection {
            get {
                return lazyConnection.Value;
            }
        }

        public static string ListRightPop(string key)
        {
            var db = Connection.GetDatabase();

            string result = db.ListRightPop(key);
            return result;
        }

        public static bool ListLeftPush(string key, string value)
        {
            var db = Connection.GetDatabase();
            bool result = db.ListLeftPush(key, value) > 0;
            return result;
        }

        public static bool Publish(string channel, string message)
        {
            ISubscriber sub = Connection.GetSubscriber();
            return sub.Publish(channel, message) > 0;
        }
    }
}
