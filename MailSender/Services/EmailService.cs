using MailKit.Net.Smtp;
using MailSender.Models;
using MimeKit;

namespace MailSender.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly ILogDbService _logDbService;

        public EmailService(IConfiguration config, ILogDbService logDbService)
        {
            _config = config;
            _logDbService = logDbService;
        }
        public void SendMail(Mail request)
        {
            foreach (var recipient in request.Recipients)
            {
                MailResponse response = new MailResponse();
                var mail = new MimeMessage();
                mail.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
                mail.To.Add(MailboxAddress.Parse(recipient.RecipientMail));
                mail.Subject = request.Subject;
                mail.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };

                try
                {
                    using var smtp = new SmtpClient();
                    smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
                    smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
                    smtp.Send(mail);
                    smtp.Disconnect(true);

                    //ВОТ ТУТ МНЕ НЕ НРАВИТСЯ
                    response.Mail = request;
                    response.Result = "Ok";
                    response.SendTime = mail.Date.DateTime;

                }
                catch (Exception ex)
                {
                    //ВОТ ТУТ МНЕ НЕ НРАВИТСЯ
                    response.Mail = request;
                    response.Result = "Failed";
                    response.SendTime = mail.Date.DateTime;
                    response.FailedMessage = "Error: " + ex.ToString();
                }
                //ВОТ ТУТ МНЕ НЕ НРАВИТСЯ
                _logDbService.LogResult(request, response);
            }
        }
    }
}
