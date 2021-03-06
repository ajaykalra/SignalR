﻿using System.Threading.Tasks;

namespace AspNetCore.SignalR.Hubs
{
    public interface IGeneralHubClient
    {
        Task BroadcastMessage(string messageType, string payload);

        Task SendMessage(string messageType, string payload);
    }
}
