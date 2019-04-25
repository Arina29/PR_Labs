using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpChat
{
    public class Data
    {
        public Data()
        {
            this.cmdCommand = Command.Null;
            this.strMessage = null;
            this.UserName = null;
        }

        public Data(byte[] data)
        {
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);

            int nameLen = BitConverter.ToInt32(data, 4);

            int msgLen = BitConverter.ToInt32(data, 8);

            if (nameLen > 0)
                this.UserName = Encoding.UTF8.GetString(data, 12, nameLen);
            else
                this.UserName = null;

            if (msgLen > 0)
                this.strMessage = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
            else
                this.strMessage = null;
        }

        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            if (UserName != null)
                result.AddRange(BitConverter.GetBytes(UserName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (strMessage != null)
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (UserName != null)
                result.AddRange(Encoding.UTF8.GetBytes(UserName));

            if (strMessage != null)
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));

            return result.ToArray();
        }

        public string UserName;
        public string strMessage;
        public Command cmdCommand;
    }
}
