using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientPrivateChat : Form
    {
        public PublicChat publicChat;
        public ClientPrivateChat(PublicChat chat)
        {
            InitializeComponent();
            publicChat = chat;
        }

        private void txtReceivedMsg_TextChanged(object sender, EventArgs e)
        {
            txtReceivedMsg.SelectionStart = txtReceivedMsg.TextLength;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtInputMsg.Text != String.Empty)
            {
                string user = Text.Split('-')[1];
                publicChat.main.client.Send("pMessage|" + user + "|" + txtInputMsg.Text);
                txtReceivedMsg.Text += user + " : " + txtInputMsg.Text + "\r\n";
                txtInputMsg.Text = String.Empty;
            }
        }
    }
}
