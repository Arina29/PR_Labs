using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace MailProtocols
{

    class Program
    {
        public static string ReadPassword()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);

            return pass;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your email:");
            var email = Console.ReadLine();

            Console.WriteLine("Enter password:");
            var password = ReadPassword();

            Console.WriteLine("\nTo:");
            var to = Console.ReadLine();

            Console.WriteLine("Body:");
            var body = Console.ReadLine();

            Console.WriteLine("Subject:");
            var subject = Console.ReadLine();

            var sender = new MailSender(email, password);

            var imagePath = "C:\\univer\\photo.jpg";
            var attachementPath = "C:\\univer\\lab1.rtf";

            sender.SendMailSmtp(to, subject, body, imagePath, attachementPath);

            var headers = sender.Pop3(5);
            foreach (var header in headers)
            {
                Console.WriteLine(header.Value);
                Console.WriteLine("-----------------------------------------");
            }
            Console.ReadLine();
        }
    }
}
