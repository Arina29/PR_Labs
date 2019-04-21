using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using OpenPop.Mime.Header;
using OpenPop.Pop3;

namespace MailProtocols
{
    public class MailSender : IMailSender
    {
        private readonly string MailAddress;
        private readonly string Password;

        public MailSender(string mailAddress, string password)
        {
            MailAddress = mailAddress;
            Password = password;
        }

        public Dictionary<int, string> Pop3(int messageNr)
        {
            Dictionary<int, string> headers = new Dictionary<int, string>();

            using (Pop3Client client = new Pop3Client())
            {
                client.Connect("pop.gmail.com", 995, true);
                client.Authenticate(MailAddress, Password);
                for (int i = 1; i <= messageNr; i++)
                {
                    var header = client.GetMessageHeaders(i);
                    RfcMailAddress from = header.From;
                    string subject = header.Subject;
                    headers.Add(i, " Subject: " + header.Subject + "\n From: " + header.From +"\n DateSent: " + header.DateSent);
                }
            }

            return headers;
        }

        public void SendMailSmtp(string to, string subject, string message, string imagePath, string attachementPath)
        {
            SmtpClient smtp = new SmtpClient();
            var mailMessage = new MailMessage(MailAddress, to, subject, message);
            mailMessage.IsBodyHtml = true;

            if (imagePath != null)
            {
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(message + "<img src=cid:Photo>", null, "text/html");
                LinkedResource image = new LinkedResource(imagePath, MediaTypeNames.Image.Jpeg);
                image.ContentId = "Photo";
                htmlView.LinkedResources.Add(image);
                mailMessage.AlternateViews.Add(htmlView);
            }
            smtp.
            else
                mailMessage.Body = message;
            if(attachementPath != null)
                mailMessage.Attachments.Add(new Attachment(attachementPath));

            smtp.Credentials = new NetworkCredential(MailAddress, Password);
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(mailMessage); 
        }
    }
}
