using MailSender.Models;
using MailSender.Services;
using Microsoft.AspNetCore.Mvc;

namespace MailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IEmailService _service;
        public MailsController(IEmailService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public void Post(Mail mail)
        {
            _service.SendMail(mail);
        }
    }
}
