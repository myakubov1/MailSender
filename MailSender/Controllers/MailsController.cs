using MailSender.Models;
using MailSender.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IEmailService _service;
        private readonly ApplicationContext _context;

        public MailsController(IEmailService service, ApplicationContext context )
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MailResponse>>> GetMails()
        {
            return await _context.Mails.ToListAsync();
        }

        [HttpPost]
        public void Post(Mail mail)
        {
            _service.SendMail(mail);
        }
    }
}
