using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientChat
    {
        private readonly Socket _socket;

        public delegate void ReceivedEventHandler(ClientChat client, string receivedMsg);

        public event ReceivedEventHandler Received = delegate { };
        public EventHandler Connected = delegate { };

        public delegate void DisconnectEventHandler(ClientChat client);

        public event DisconnectEventHandler Disconnected = delegate { };
        private bool _isConnected;

        public ClientChat()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private EndPoint _endPoint;
        public void Connect(string ip, int port)
        {
            var endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            _endPoint = endPoint;
            _socket.BeginConnect(endPoint, ConnectCallback, _socket);
        }

        public void Close()
        {
            _socket.Dispose();
            _socket.Close();
        }

        void ConnectCallback(IAsyncResult ar)
        {
            //_socket.EndConnect(ar);
            _isConnected = true;
            Connected(this, EventArgs.Empty);
            var buffer = new byte[_socket.ReceiveBufferSize];
            _socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None,ref _endPoint, ReadCallback, buffer);
        }

        void ReadCallback(IAsyncResult asyncResult)
        {
            var buffer = (byte[]) asyncResult.AsyncState;
            var rec = _socket.EndReceive(asyncResult);
            if (rec != 0)
            {
                var data = Encoding.ASCII.GetString(buffer, 0, rec);
                Received(this, data);
            }
            else
            {
                Disconnected(this);
                _isConnected = false;
                Close();
                return;
            }
            _socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReadCallback, buffer);
        }

        public void Send(string data)
        {
            try
            {
                var buffer = Encoding.ASCII.GetBytes(data);
                _socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, buffer);
            }
            catch
            {
                Disconnected(this);
            }
        }

        void SendCallback(IAsyncResult ar)
        {
            _socket.EndSend(ar);
        }
    }
}
