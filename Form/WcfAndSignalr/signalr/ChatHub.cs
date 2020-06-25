using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAndSignalr.signalr
{
    [HubName("TestHub")]
    public class ChatHub : Hub
    {
        public void Send(List<string> userId, string message)
        {
            Clients.Users(userId).send(message);
        }
    }
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            var userId = request.Headers["userId"];
            return userId.ToString();
        }
    }
}
