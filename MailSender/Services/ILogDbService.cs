using MailSender.Models;

namespace MailSender.Services
{
    public interface ILogDbService
    {
        Task LogResult(Mail request, MailResponse response);
    }
}
