using Shared.Models;

namespace Shared.Abstract
{
    public interface IEmailService
    {
        void SendEmail(string receiverName, string receiverEmail, string subject, string message, string templateName);
        void SendEmail(Mail mail);
    }
}
