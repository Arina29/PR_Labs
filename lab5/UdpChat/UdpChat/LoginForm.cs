﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace UdpChat
{
    public partial class LoginForm : Form
    {

        public Socket clientSocket;
        public EndPoint epServer;
        public string UserName;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            UserName = txtUsername.Text;
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram, ProtocolType.Udp);

                IPAddress ipAddress = IPAddress.Parse(txtIp.Text);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 1000);

                epServer = (EndPoint)ipEndPoint;

                Data msgToSend = new Data();
                msgToSend.cmdCommand = Command.Login;
                msgToSend.strMessage = null;
                msgToSend.UserName = UserName;

                byte[] byteData = msgToSend.ToByte();

                //Login to the server
                clientSocket.BeginSendTo(byteData, 0, byteData.Length,
                    SocketFlags.None, epServer, new AsyncCallback(OnSend), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SGSclient",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
                UserName = txtUsername.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SGSclient", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0 && txtIp.Text.Length > 0)
                btnConnect.Enabled = true;
            else
                btnConnect.Enabled = false;
        }

        private void txtIp_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0 && txtIp.Text.Length > 0)
                btnConnect.Enabled = true;
            else
                btnConnect.Enabled = false;
        }
    }
}
