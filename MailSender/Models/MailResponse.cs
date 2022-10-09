namespace MailSender.Models
{
    public class MailResponse
    {
        public int Id { get; set; }
        public Mail Mail { get; set; }
        public DateTime SendTime { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }
    }
}
