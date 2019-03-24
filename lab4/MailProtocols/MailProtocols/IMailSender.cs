using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProtocols
{
    public interface IMailSender
    {
        Dictionary<int, string> Pop3(int messageNr);

        void SendMailSmtp(string to, string subject, string message, string imagePath, string attachementPath);
    }
}
