using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace mvcProjectvs.Controllers
{
    public class MailController : Controller
    {
        public class MailService
        {
            private string senderMailAddress = "softwareionicc@hotmail.com";
            private string senderMailPass = "kekobabam123";
            private int mailServerPort = 587;
            private string mailServerHost = "smtp.live.com";
            private bool mailServerSSL = true;
            public void UserWelcomeMail(string userMailAddress)
            {
                MailMessage message = new MailMessage();
                SmtpClient mailServer = new SmtpClient();
                mailServer.Credentials = new System.Net.NetworkCredential(senderMailAddress, senderMailPass);
                mailServer.Port = mailServerPort;
                mailServer.Host = mailServerHost;
                mailServer.EnableSsl = mailServerSSL;
                message.To.Add(userMailAddress);
                message.From = new MailAddress("softwareionicc@hotmail.com");
                message.Subject = "Welcome/Hoşgeldiniz";
                message.Body = "deneme";
                mailServer.Send(message);
            }
            
        }
    }
}