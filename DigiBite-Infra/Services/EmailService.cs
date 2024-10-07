using DigiBite_Core.DTOs.Email;
using DigiBite_Core.IServices;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
namespace DigiBite_Infra.Services
{
    public class EmailService(IConfiguration config) : IEmailService
    {
        public bool SendMail(EmailDTO Mail_Data)
        {
            try
            {
                //MimeMessage - a class from Mimekit
                MimeMessage email_Message = new MimeMessage();
                MailboxAddress email_From = new MailboxAddress(config["MailSettings:Name"], config["MailSettings:EmailId"]);
                email_Message.From.Add(email_From);
                MailboxAddress email_To = new MailboxAddress(Mail_Data.EmailToName, Mail_Data.EmailToId);
                email_Message.To.Add(email_To);
                email_Message.Subject = Mail_Data.EmailSubject;
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = Mail_Data.EmailBody;
                email_Message.Body = emailBodyBuilder.ToMessageBody();
                //this is the SmtpClient class from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                SmtpClient MailClient = new SmtpClient();
                MailClient.Connect(config["MailSettings:Host"], int.Parse(config["MailSettings:Port"]), bool.Parse(config["MailSettings:UseSSL"]));
                MailClient.Authenticate(config["MailSettings:EmailId"], config["MailSettings:Password"]);
                MailClient.Send(email_Message);
                MailClient.Disconnect(true);
                MailClient.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                return false;
            }
        }
    }
}

