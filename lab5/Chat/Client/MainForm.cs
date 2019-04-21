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
    public partial class MainForm : Form
    {
        public ClientChat client { get; set; }

        public MainForm()
        {
            client = new ClientChat();
            InitializeComponent();  
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client.Connected += Client_Connected;
            client.Connect(txtIP.Text, 2014);
            client.Send("Connect|"+txtUsername.Text +"|connected");
        }

        private void Client_Connected(object sender, EventArgs e)
        {
            this.Invoke(Close);
        }
    }
}
