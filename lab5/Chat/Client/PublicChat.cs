using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class PublicChat : Form
    {

        public PublicChat()
        {
            pChat = new ClientPrivateChat(this);
            InitializeComponent();
        }

        public readonly MainForm main = new MainForm();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            main.client.Received += Client_Received;
            main.client.Disconnected += Client_Disconnected;
            Text = "Chat - " + main.txtIP.Text + "- Connected with username - " + main.txtUsername.Text;
            main.ShowDialog();
        }


        private static void Client_Disconnected(ClientChat clientChat)
        {

        }

        private readonly ClientPrivateChat pChat;

        public void Client_Received(ClientChat client, string receivedMsg)
        {
            var cmd = receivedMsg.Split('|');
            switch (cmd[0])
            {
                case "Users":
                    this.Invoke(() =>
                        {
                            userList.Items.Clear();
                            for (int i = 1; i < cmd.Length; i++)
                            {
                                if (cmd[i] != "Connected" | cmd[i] != "RefreshChat")
                                {
                                    userList.Items.Add(cmd[i]);
                                }
                            }
                        }
                    );
                    break;

                case "Message":
                    this.Invoke(() => { txtReceivedMsg.Text += cmd[1] + "\r\n"; });
                    break;

                case "RefreshChat":
                    this.Invoke(() => { txtReceivedMsg.Text = cmd[1]; });
                    break;

                case "Chat":
                    this.Invoke(() =>
                    {
                        pChat.Text = pChat.Text.Replace("user", main.txtUsername.Text);
                        pChat.Show();
                    });
                    break;
                case "pMessage":
                    this.Invoke(() => { pChat.txtReceivedMsg.Text += "Server: " + cmd[1] + "\r\n"; });
                    break;
                case "Disconnect":
                    Application.Exit();
                    break;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtInputMsg.Text != String.Empty)
            {
                main.client.Send("Message|" + main.txtUsername.Text + "|" + txtInputMsg.Text);
                txtReceivedMsg.Text += main.txtUsername.Text + " : " + txtInputMsg.Text + "\r\n";
                txtInputMsg.Text = String.Empty;
            }
        }

        private void Input_EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }

        private void txtReceivedMsg_TextChanged(object sender, EventArgs e)
        {
            txtReceivedMsg.SelectionStart = txtReceivedMsg.TextLength;
        }

        private void privateChat_Click(object sender, EventArgs e)
        {
            main.client.Send("pChat|" + main.txtUsername.Text);
        }
    }
}
