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
            Send("chou0015@stthomas.edu", "UST-GRADS", "test", "test", new List<string>() { "chou0015@stthomas.edu" });
        }

        static void Send(string spoofedAddress, string spoofedName, string body, string subject, List<string> Recipients)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    Recipients.ForEach(Recipient => message.Bcc.Add(Recipient));
                    message.From = new MailAddress(spoofedAddress, spoofedName);
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    var client = new SmtpClient("smtp.stthomas.edu", 587)
                    {
                        Timeout = 30000,
                        Credentials = new NetworkCredential("chou0015", "Stthomas1"),
                        EnableSsl = true
                    };

                    client.Send(message);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
