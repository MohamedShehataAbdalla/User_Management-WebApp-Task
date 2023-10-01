using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace User_Management_WebApp.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("shehata.mohamed.it@gmail.com", "rznvgvwywhgqpnzk"),
                EnableSsl = true,
            };
            return smtpClient.SendMailAsync("shehata.mohamed.it@gmail.com", email, subject, htmlMessage);
        }

        //public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //    var fromMail = "shehata.mohamed.it@gmail.com";
        //    var fromPassword = "rznvgvwywhgqpnzk";

        //    var message = new MailMessage();
        //    message.Subject = subject;
        //    message.To.Add(email);
        //    message.Body = $"<html><body> {htmlMessage} </body></html>";
        //    message.IsBodyHtml = true;

        //    //smtp.gmail.com => 587
        //    //smtp-mail.outlook.com => 587

        //    var smtpClient = new SmtpClient("smtp.gmail.com")
        //    {
        //        Port = 587,
        //        Credentials = new NetworkCredential(fromMail, fromPassword),
        //        EnableSsl = true,
        //    };

        //    smtpClient.Send(message);
        //}
    }
}
