using System.Collections.Generic;

namespace Shared.Models
{
    public class Mail
    {
        public string MailFrom { get; set; }
        public string MailTo { get; set; }
        public string MailCc { get; set; }
        public string MailBcc { get; set; }
        public string MailSubject { get; set; }
        public string MailContent { get; set; }
        public string TemplateName { get; set; }
        public List<object> Attachments { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
    }
}
