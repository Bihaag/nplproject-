using GymServices.Utils.Interface;
using System.Net;
using System.Net.Mail;

namespace GymServices.Utils
{
    public class Mail : IMail
    {
        public void EmailSend(string body, string to, string subject)
        {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("duttest2022@yahoo.com");
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.mail.yahoo.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("duttest2022@yahoo.com", "ysqcwofuuxoabdnk");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
        }
    }
}
