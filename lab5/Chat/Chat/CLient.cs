using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Chat
{
    class CLient
    {
        public delegate void ClientReceiveHandler(CLient sender, byte[] data);

        public delegate void ClinetDisconnectHandler(CLient sender);

        public event ClientReceiveHandler Received;

        public event ClinetDisconnectHandler Disonnected;
        
        public IPEndPoint Ip { get; private set; }

        public Socket _socket;

        public CLient(Socket acceptedSocket)
        {
            _socket = acceptedSocket;
            Ip = (IPEndPoint) _socket.RemoteEndPoint;
            _socket.BeginReceive(new byte[] {0}, 0, 0, 0, Callback, null );
        }

        void Callback(IAsyncResult asyncResult) // in this way Server get messages
        {
            try
            {
                _socket.EndReceive(asyncResult);
                var buffer = new byte[_socket.ReceiveBufferSize];
                var rec = _socket.Receive(buffer, buffer.Length, 0);
                if (rec < buffer.Length)
                    Array.Resize(ref buffer, rec);
                Received?.Invoke(this, buffer);
                _socket.BeginReceive(new byte[] {0}, 0, 0, 0, Callback, null);
            }
            catch (Exception e)
            {
                Close();
                Disonnected?.Invoke(this);
            }
        }

        public void Send(string data) // server send something to the client
        {
            var buffer = Encoding.ASCII.GetBytes(data);
            _socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, ar => _socket.EndSend(ar), buffer);
        }

        public void Close()
        {
            _socket.Dispose();
            _socket.Close();
        }

    }
}
