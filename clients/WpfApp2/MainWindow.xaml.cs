using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.AspNetCore.SignalR.Client;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HubConnection connection;
        
        public MainWindow()
        {
            InitializeComponent();
            InitSignalR("http://somechat.westeurope.cloudapp.azure.com/chat");
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            connection.InvokeAsync("Send", NameField.Text, TextField.Text);
            NameField.Text = "";
            TextField.Text = "";
        }
        
        private async Task InitSignalR(string connectionUrl)
        {
            connection = new HubConnectionBuilder()
                .WithUrl(connectionUrl)
                .Build();
            
            await connection.StartAsync();

            connection.On<string, string>("sendMessage", (user, message) =>
            {
                var textRaw = $"{user}: {message}";
                var items = ChatList.Items;
                items.Add(textRaw);
            });

            connection.On<List<dynamic>>("getData", data =>
            {
                foreach (var dataRaw in data)
                {
                    var jsonEl = (JsonElement) dataRaw;
                    var nickname = jsonEl.GetProperty("nickname").GetString();
                    var message = jsonEl.GetProperty("message").GetString();

                    var textRaw = $"{nickname}: {message}";
                    var items = ChatList.Items;
                    items.Add(textRaw);
                }
            });

            await connection.InvokeAsync("GetData");
        }
    }
}