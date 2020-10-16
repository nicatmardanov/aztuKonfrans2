using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aztuKonfrans2.Classes
{
    public class Mail
    {
        public static void SendMail(string toMail, string subject, string body)
        {

            using (System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient())
            {
                smtpClient.Host = "outlook.office365.com";
                //smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                //System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress("info@az-tr-conference2019.com");
                System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress("az-tr-conference2019@hotmail.com");
                System.Net.Mail.MailAddress toAddress = new System.Net.Mail.MailAddress(toMail);
                //smtpClient.Credentials = new System.Net.NetworkCredential("info@az-tr-conference2019.com", "A2tu1ntern4tio.");
                smtpClient.Credentials = new System.Net.NetworkCredential("az-tr-conference2019@hotmail.com", "A2tu1ntern4tionalDep./");

                message.From = fromAddress;
                message.To.Add(toAddress);
                message.IsBodyHtml = true;
                message.Subject = subject;
                message.Body = body;

                smtpClient.Send(message);

            }

        }
    }
}