using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UdpChat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
            if (loginForm.DialogResult == DialogResult.OK)
            {
                Client sgsClientForm = new Client();
                sgsClientForm.clientSocket = loginForm.clientSocket;
                sgsClientForm.UserName = loginForm.UserName;
                sgsClientForm.epServer = loginForm.epServer;

                sgsClientForm.ShowDialog();
            }
        }
    }
}
