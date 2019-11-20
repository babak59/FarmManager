using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Shared.Abstract;
using Shared.Models;
using Shared.Settings;
using System;
using System.IO;
using System.Text;

namespace Shared.Services
{
    public class EmailService : IEmailService
    {
        #region Private fields

        private EmailSettings _emailSettings;

        #endregion
        #region Constructors

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        #endregion
        #region Public methods

        public void SendEmail(string receiverName, string receiverEmail, string subject, string message, string templateName)
        {
            throw new System.NotImplementedException();
        }

        public void SendEmail(Mail mail)
        {
            StringBuilder textBuilder = new StringBuilder();
            BodyBuilder bodyBuilder = new BodyBuilder(); ;

            if (string.IsNullOrEmpty(mail.TemplateName))
            {
                throw new Exception("Template name can't be null or empty!");
            }

            using (StreamReader reader = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\..\\Shared\\Templates\\" + mail.TemplateName))
            {
                textBuilder.Append(reader.ReadToEnd());
            }

            ReplaceAttributes(textBuilder, mail);

            bodyBuilder.HtmlBody = textBuilder.ToString();
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Farm manager - your farm assistant", _emailSettings.Username));
            message.To.Add(new MailboxAddress(mail.MailTo));
            message.Subject = mail.MailSubject;
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.Ssl);
                client.Authenticate(_emailSettings.Username, _emailSettings.Password);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        #endregion
        #region Private methods

        private void ReplaceAttributes(StringBuilder builder, Mail mail)
        {
            foreach (var attribute in mail.Attributes)
            {
                builder.Replace("${" + attribute.Key + "}", attribute.Value.ToString());
            }
        }

        #endregion
    }
}
