using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Console_client
{
    public class Chat
    {
        private HubConnection _connection { get; }
        private string _nickName { get; }
        public Chat(string url)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();
            Console.WriteLine("Введите никнейм");
            _nickName = Console.ReadLine();
        }

        /// <summary>
        /// Старт чата
        /// </summary>
        public async Task Start()
        {
            ObservableCollection<string> collection = new ObservableCollection<string>();

            collection.CollectionChanged += CollectionChanged;
            await _connection.StartAsync();

            Thread reader = new Thread(new ThreadStart(Reader));
            reader.Start();

            _connection.On<List<dynamic>>("getData", data =>
            {
                foreach (var dataRaw in data)
                {
                    var jsonEl = (JsonElement)dataRaw;
                    var nickname = jsonEl
                    .GetProperty("nickname")
                    .GetString();
                    var message = jsonEl
                    .GetProperty("message")
                    .GetString();
                    collection.Add($"{nickname}: {message}");
                }
            });

            _connection.On<string, string>("sendMessage", (message, user) =>
            {
                collection.Add($"{user}: {message}");
            });

            await _connection.InvokeAsync("GetData");

        }

        
        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (string item in e.NewItems)
                Console.WriteLine(item);
        }


        /// <summary>
        /// Чтение консоли
        /// </summary>
        private void Reader()
        {
            Console.WriteLine("Для завершения напишите: /");
            while (true)
            {
                var message = Console.ReadLine();
                if (message == "/") return;

                _connection.InvokeAsync("Send", message, _nickName);
            }
        }
    }
}