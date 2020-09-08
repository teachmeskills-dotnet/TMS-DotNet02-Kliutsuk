using EasyMeeting.BLL.Constants;
using EasyMeeting.Common.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace EasyMeeting.BLL.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта Easy Meeting", EmailConstants.MESSAGE_SENDER_ADDRESS));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(EmailConstants.SMTP_GOOGLE, 587, false);
                await client.AuthenticateAsync(EmailConstants.MESSAGE_SENDER_ADDRESS, EmailConstants.EMAIL_PASSWORD);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}