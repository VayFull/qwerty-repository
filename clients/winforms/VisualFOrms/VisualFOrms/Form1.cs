using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualFOrms
{
    public partial class Form1 : Form
    {
        HubConnection connection;
        ObservableCollection<string> collection = new ObservableCollection<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            collection.CollectionChanged += CollectionChanged;
            InitSignalR("http://somechat.westeurope.cloudapp.azure.com/chat");
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (string item in e.NewItems)
            {
                chat.Lines = chat.Lines.Append(item).ToArray();
            }
            chat.Refresh();
        }

        private async Task InitSignalR(string connectionUrl)
        {
            connection = new HubConnectionBuilder()
                .WithUrl(connectionUrl)
                .Build();
            
            await connection.StartAsync();

            connection.On<string, string>("sendMessage", (message, user) =>
            {
                var textRaw = $"{user}: {message}";
                chat.Lines = chat.Lines.Append(textRaw).ToArray();
                chat.Refresh();
            });

            connection.On<List<dynamic>>("getData", data =>
            {
                foreach (var dataRaw in data)
                {
                    var jsonEl = (JsonElement) dataRaw;
                    var nickname = jsonEl.GetProperty("nickname").GetString();
                    var message = jsonEl.GetProperty("message").GetString();

                    var textRaw = $"{nickname}: {message}";
                    collection.Add(textRaw);
                }
            });

            await connection.InvokeAsync("GetData");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.InvokeAsync("Send", message.Text, name.Text);
        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
