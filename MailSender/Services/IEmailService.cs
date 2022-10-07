using MailSender.Models;

namespace MailSender.Services
{
    public interface IEmailService
    {
        void SendMail(Mail request);

    }
}
