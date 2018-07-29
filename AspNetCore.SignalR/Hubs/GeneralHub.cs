using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace AspNetCore.SignalR.Hubs
{
    public class GeneralHub : Hub<IGeneralHubClient>
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string messageType, string payload)
        {
           await Clients.All.BroadcastMessage(messageType, payload);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
