using MailSender.Models;

namespace MailSender.Services
{
    public interface ILogDbService
    {
        void LogResult(Mail request, MailResponse response);
    }
}
