using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    class Listener
    {
        private Socket _socket;

        public bool Listening { get; private set; }

        public int Port { get; private set; }

        public Listener(int port)
        {
            Port = port;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            if (Listening) return;
            _socket.Bind(new IPEndPoint(0, Port));
            _socket.Listen(0);
            _socket.BeginAccept(Callback, null);
            Listening = true;
        }

        public void Stop()
        {
            if (!Listening) return;
            if (_socket.Connected)
                _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler SocketAccepted;

        public void Callback(IAsyncResult asyncResult)
        {
            try
            {
                var newSocket = _socket.EndAccept(asyncResult);
                if (SocketAccepted != null)
                    SocketAccepted(newSocket);
                _socket.BeginAccept(Callback, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
