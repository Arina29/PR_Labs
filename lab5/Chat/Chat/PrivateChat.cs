using Chat;
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
    public partial class PrivateChat : Form
    {
        private readonly Main Main;

        public PrivateChat(Main main)
        {
            InitializeComponent();
            Main = main;
        }

        private void txtInput_EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtInputMsg.Text != String.Empty)
            {
                foreach (var client in from ListViewItem item in Main.lstClients.SelectedItems select (CLient) item.Tag)
                {
                    client.Send("pMessage|" + txtInputMsg.Text);
                }

                txtReceivedMsg.Text += "Server: " + txtInputMsg.Text + "\r\n";
                txtInputMsg.Text = string.Empty;
            }
        }

        private void txtInputMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReceivedMsg_TextChanged(object sender, EventArgs e)
        {
            txtReceivedMsg.SelectionStart = txtReceivedMsg.TextLength;
        }
    }
}
