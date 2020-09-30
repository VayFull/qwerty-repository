using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleApp2
{
    class Program
    {
        static HubConnection connection;
        private static bool flag = false;
        
        static async Task Main(string[] args)
        {
            await InitSignalR("https://localhost:5001/chat");
            while (!flag)
            {
                await Task.Delay(100);
            }
            MainLoop();
        }

        private static void MainLoop()
        {
            Console.WriteLine("Enter your nickname:");
            var nickname = Console.ReadLine();
            Console.WriteLine("Enter your messages below:");
            while (true)
            {
                var line = Console.ReadLine();
                connection.InvokeAsync("Send", nickname, line);
            }
        }
        
        private static async Task InitSignalR(string connectionUrl)
        {
            connection = new HubConnectionBuilder()
                .WithUrl(connectionUrl)
                .Build();
            
            await connection.StartAsync();

            connection.On<string, string>("sendMessage", (user, message) =>
            {
                var textRaw = $"{user}: {message}";
                Console.WriteLine(textRaw);
            });

            connection.On<List<dynamic>>("getData", data =>
            {
                foreach (var dataRaw in data)
                {
                    var jsonEl = (JsonElement) dataRaw;
                    var nickname = jsonEl.GetProperty("nickname").GetString();
                    var message = jsonEl.GetProperty("message").GetString();

                    var textRaw = $"{nickname}: {message}";
                    Console.WriteLine(textRaw);
                }

                flag = true;
            });

            await connection.InvokeAsync("GetData");
        }
    }
}