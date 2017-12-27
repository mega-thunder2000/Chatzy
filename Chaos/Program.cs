using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Chaos
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void Send(string spoofedAddress, string body, string subject, List<string> Recipients)
        {
            using (var message = new MailMessage())
            {
                Recipients.ForEach(Recipient => message.Bcc.Add(Recipient));
                message.From = new MailAddress("spoofed@ust.edu", spoofedAddress);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                var client = new SmtpClient()
                {
                    Timeout = 30000,
                    Credentials = new NetworkCredential(),
                    EnableSsl = false
                };

                client.Send(message);
            }
        }
    }
}
