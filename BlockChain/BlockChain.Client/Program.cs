using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlockChain.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static HubConnection connection;
        static async Task MainAsync(string[] args)
        {
            connection = new HubConnectionBuilder()
                       .WithUrl("http://localhost:54816/transactions")
                       .Build();

            await connection.StartAsync();

            connection.On<string, string>("Listen", Listen);

            Console.WriteLine("Connection started, press one key to abort it....");
            Console.ReadKey();

            await connection.StopAsync();
        }

        static void Listen(string user, string message)
        {
            var transaction = new Transaction
            {
                Data = message,
                Timestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds,
                PublicKey = user
            };

            using (var repository = new GenericRepository<Transaction>())
            {
                repository.Add(transaction);
            }
        }
    }
}
