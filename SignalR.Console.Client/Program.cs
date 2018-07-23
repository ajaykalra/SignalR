using System;
using System.Net.Http;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalR.Console.Client
{
    class Program
    {
        private static readonly Uri _hubRUri = new Uri("http://localhost:40181/GeneralHub/");
        private static readonly Uri _signalRUri = new Uri("http://localhost:40181/api/");

        static void Main(string[] args)
        {
            System.Console.ReadLine();

            TestSignalUri();
            System.Console.ReadLine();
        }

        static async void TestSignalUri()
        {
            HubConnection connection = new HubConnectionBuilder()
                                           .WithUrl(_hubRUri)
                                           .Build();

            connection.On<string, string>("BroadcastMessage", (messageType, payLoad) =>
            {
                System.Console.WriteLine(messageType, payLoad);
            });

            try
            {
                await connection.StartAsync();              
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _signalRUri;
                var payload = new
                {
                    MessageType = "SomeType",
                    Payload = "SomePayload"
                };

                var task = await httpClient.PostAsJsonAsync<dynamic>("message", payload);
                
            }


        }


    }
}
