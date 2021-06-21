using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtMe.Server.Hubs
{
    public class TextMessageReceivedHub : Hub
    {
        public async Task SendMessage(string from, string to, string message)
        {
            await Clients.All.SendAsync("TextMessageReceived", from, to, message);
        }
    }
}
