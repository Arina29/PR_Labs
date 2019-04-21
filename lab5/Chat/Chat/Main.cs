using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;

namespace Chat
{
    public partial class Main : Form
    {
        private readonly Listener _listener;

        public List<Socket> clients = new List<Socket>();

        private PrivateChat pChat;

        public void BroadcastData(string data) // send messages to all clients
        {
            foreach (var socket in clients)
            {
                try
                {
                    socket.Send(Encoding.ASCII.GetBytes(data));
                }
                catch (Exception) { }
            }
        }

        public Main()
        {
            pChat = new PrivateChat(this);
            InitializeComponent();
            _listener = new Listener(2014);
            _listener.SocketAccepted += Listener_SocketAccepted;
        }

        private void Listener_SocketAccepted(Socket socket)
        {
            var client = new CLient(socket);
            client.Received += Client_Received;
            client.Disonnected += Client_Disconnected;

            this.Invoke(() =>
            {
                string ipAdress = client.Ip.ToString().Split(':')[0];
                var item = new ListViewItem(ipAdress);
                item.SubItems.Add(" ");
                item.SubItems.Add(" ");
                item.Tag = client;
                lstClients.Items.Add(item);
                clients.Add(socket);
            });
        }

        private void Client_Disconnected(CLient sender)
        {
            this.Invoke(() =>
            {
                for (int i = 0; i < lstClients.Items.Count; i++)
                {
                    var client = lstClients.Items[i].Tag as CLient;
                    if (client.Ip == sender.Ip)
                    {
                        txtReceive.Text += lstClients.Items[i].SubItems[1].Text + " !!! Has Left the Chat !!!\r\n";
                        BroadcastData("RefreshChat|" + txtReceive.Text);
                        lstClients.Items.RemoveAt(i);
                    }
                }
            });
        }

        private void Client_Received(CLient sender, byte[] data)
        {
            this.Invoke(() =>
            {
                for (int i = 0; i < lstClients.Items.Count; i++)
                {
                    var client = lstClients.Items[i].Tag as CLient;
                    if (client == null || client.Ip != sender.Ip) continue;
                    var command = Encoding.ASCII.GetString(data).Split('|');

                    switch (command[0])
                    {
                        case "Connect":
                            txtReceive.Text += command[1] + " *** Joined The Chat *** \r\n";
                            lstClients.Items[i].SubItems[1].Text = command[1];
                            lstClients.Items[i].SubItems[2].Text = command[2];
                            string users = string.Empty;
                            for (int j = 0; j < lstClients.Items.Count; j++)
                            {
                                users += lstClients.Items[j].SubItems[1].Text + "|";
                            }
                            BroadcastData("Users|" + users.TrimEnd('|'));
                            BroadcastData("RefreshChat|" + txtReceive.Text);
                            break;

                        case "Message":
                            txtReceive.Text += command[1] + " : " + command[2] + "\r\n";
                            BroadcastData("RefreshChat|" + txtReceive.Text);
                            break;
                        case "pMessage":
                            this.Invoke(
                                () => { pChat.txtReceivedMsg.Text += command[1] + " : " + command[2] + "\r\n"; });
                            break;
                        case "pChat":
                            break;
                    }
                }
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != string.Empty)
            {
                BroadcastData("Message|" + txtInput.Text);
                txtReceive.Text += txtInput.Text + "\r\n";
                txtInput.Text = "Admin: ";
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _listener.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _listener.Stop();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var client in from ListViewItem item in lstClients.SelectedItems
                select (CLient) item.Tag)
            {
                client.Send("Disconnect|");
            }
        }

        private void chatWithClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var client in from ListViewItem item in lstClients.SelectedItems
                select (CLient) item.Tag)
            {
                client.Send("Chat|");
                pChat = new PrivateChat(this);
                pChat.Show();
            }
        }

        private void txtInput_EnterKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnSend.PerformClick();
        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            txtReceive.SelectionStart = txtReceive.TextLength;
        }
    }
}
