using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BuildingDemo.Areas.Admin.Controllers
{
    public class EmailController : Controller
    {
        private const string SenderEmail = "hakoru1a@gmail.com";
        private const string Password = "kgcuztrpvwdolkfa";
        public static void SendEmail(string toEmail, string message, string subject)
        {

            try
            {
                MailMessage mailMessage = new MailMessage();
                //var senderEmail = new MailAddress(SenderEmail, "Your Name");
                //var receiverEmail = new MailAddress(toEmail, "Receiver");
                var smtp = new SmtpClient {
                    Host = "smtp.gmail.com", // for gmail
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential() {
                        UserName=SenderEmail,
                        Password=Password
                    }
                };
                MailAddress fromAdress = new MailAddress(SenderEmail, "Công Ty TNHH CB");
                mailMessage.From = fromAdress;
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                smtp.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error sending email to {toEmail}: {ex.Message}");
            }
        }
    }
}