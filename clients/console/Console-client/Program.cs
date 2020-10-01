using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;

namespace Console_client
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = @"http://somechat.westeurope.cloudapp.azure.com/chat";

            var chat = new Chat(url);
            chat.Start().Wait();
        }
    }
}
