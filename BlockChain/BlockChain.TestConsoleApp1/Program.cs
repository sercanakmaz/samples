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

            //new Thread(() =>
            //{
            //    connection.On<string, string>("Listen", (user, message) =>
            //    {
            //        Add(new Transaction
            //        {
            //            Data = message,
            //            Timestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds,
            //            PublicKey = user
            //        });
            //    });
            //}).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 500; i++)
                {
                    connection.SendAsync("Add", i, $"test{i}");
                    Thread.Sleep(500);
                }
            }).Start();

            Console.WriteLine("Hello World!");
        }

        static void Add(Transaction transaction)
        {
            using (StockChainContext context = new StockChainContext())
            {
                var transactionSet = context.Set<Transaction>();

                transactionSet.Add(transaction);

                context.SaveChanges();
            }
        }
    }
}
