using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebApplication.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly List<UserMessage> UserMessages = new List<UserMessage>();
        
        public Task Send(string message, string nickname)
        {
            UserMessages.Add(new UserMessage(message, nickname));
            return Clients.All.SendAsync("sendMessage", message, nickname);
        }

        public Task GetData() =>
            Clients.Caller.SendAsync("getData", UserMessages);
        
    }

    internal class UserMessage
    {
        public UserMessage(string message, string nickname)
        {
            Nickname = nickname;
            Message = message;
        }
        
        public string Nickname { get; set; }
        public string Message { get; set; }
    }
}