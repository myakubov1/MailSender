using MailSender.Models;
using Microsoft.EntityFrameworkCore;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace MailSender.Services
{
    public class LogDbService : ILogDbService
    {
        private readonly ApplicationContext _context;

        public LogDbService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task LogResult(Mail request, MailResponse response)
        {
            _context.Mails.Add(response);
            await _context.SaveChangesAsync();

        }
    }
}
