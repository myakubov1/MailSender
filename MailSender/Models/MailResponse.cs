namespace MailSender.Models
{
    public class MailResponse
    {
        public DateTime SendTime { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }
    }
}
