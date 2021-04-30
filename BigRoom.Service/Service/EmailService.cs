
using BigRoom.Service.IService;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<MailSettings> _mailSettings;

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            this._mailSettings = mailSettings;
        }
        public async Task SendAsync(string to, string body, string subject)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Value.Mail);
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_mailSettings.Value.Host, _mailSettings.Value.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Value.Mail, _mailSettings.Value.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }
    }
}
