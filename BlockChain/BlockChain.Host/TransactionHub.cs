using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain.Host
{
    public class TransactionHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendCoreAsync("ReceiveMessage", new object[] { message });
        }
    }
}
