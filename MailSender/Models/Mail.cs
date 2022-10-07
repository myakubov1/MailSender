namespace MailSender.Models
{
    public class Mail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Recipients { get; set; }

    }
}
