using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace aztuKonfrans2.Classes
{
    public class EMail
    {
        public static void SendMail(string toMail, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("info@az-tr-conference2019.com");
                message.To.Add(new MailAddress(toMail));
                message.Bcc.Add(new MailAddress("info@az-tr-conference2019.com"));
                message.Subject = subject;
                message.IsBodyHtml = true;
                //message.Body = body;
                message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(body, new System.Net.Mime.ContentType("text/html")));
                
                


                SmtpClient smtp = new SmtpClient();
                smtp.Port = 25;
                smtp.Host = "relay-hosting.secureserver.net";
                smtp.EnableSsl = false;
                smtp.Credentials = new NetworkCredential("info@az-tr-conference2019.com", "A2tu1ntern4tio.");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                smtp.Dispose();

                

            }
            catch (Exception)
            {

            }
        }

    }
}