using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;

namespace BlockChain.TestConsoleApp1
{
    class Program
    {
        static HubConnection connection;
        static void Main(string[] args)
        {
            connection = new HubConnectionBuilder()
                       .WithUrl("http://localhost:54816/transactions")
                       .Build();

            connection.StartAsync();

            new Thread(() =>
            {
                connection.On<string>("ReceiveMessage", (message) =>
                {
                    Console.WriteLine(message);
                });
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 500; i++)
                {
                    connection.SendAsync("SendMessage", $"test{i}");
                    Thread.Sleep(500);
                }
            }).Start();

            Console.WriteLine("Hello World!");
        }
    }
}
