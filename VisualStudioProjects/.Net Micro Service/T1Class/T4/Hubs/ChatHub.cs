using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T4.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMsg(string user, string msg)
        {
            await Clients.All.SendAsync("ReceiveMsg", user, msg);
        }
    }
}
