using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace mvcProjectvs.Services
{
    public class MailService
    {
        private string senderMailAddress = "softwareionicc@hotmail.com";
        private string senderMailPass = "kekobabam123";
        private int mailServerPort = 587;
        private string mailServerHost = "smtp-mail.outlook.com";
        private bool mailServerSSL = true;
        public void SendWelcomeMail(string Email)
        {
            MailMessage message = new MailMessage();
            SmtpClient mailServer = new SmtpClient();
            mailServer.Credentials = new System.Net.NetworkCredential(senderMailAddress, senderMailPass);
            mailServer.UseDefaultCredentials = false;
            mailServer.Port = mailServerPort;
            mailServer.Host = mailServerHost;
            mailServer.EnableSsl = mailServerSSL;
            message.To.Add(Email);
            message.From = new MailAddress("softwareionicc@hotmail.com");
            message.Subject = "Welcome/Hoşgeldiniz";
            message.Body = "Deneme";
            mailServer.Send(message);
        }
        public void SendForgotMail(string Email)
        {
            MailMessage message = new MailMessage();
            SmtpClient mailServer = new SmtpClient();
            mailServer.Credentials = new System.Net.NetworkCredential(senderMailAddress, senderMailPass);
            mailServer.UseDefaultCredentials = false;
            mailServer.Port = mailServerPort;
            mailServer.Host = mailServerHost;
            mailServer.EnableSsl = mailServerSSL;
            message.To.Add(Email);
            message.From = new MailAddress("softwareionicc@hotmail.com");
            message.Subject = "Aşağıdaki linkten şifre sıfırlamaya ulaşabilirsiniz";
            message.Body = "Deneme";
            mailServer.Send(message);
        }


    }
}