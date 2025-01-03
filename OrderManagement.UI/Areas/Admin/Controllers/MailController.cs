using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OrderManagement.UI.DTOs.MailDTOs;
using MailKit.Net.Smtp;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDTO createMailDTO)
        {
            var mimeMessage = new MimeMessage();

            var mailBoxAddressFrom = new MailboxAddress("M&Y Restoran Rezervasyon", "mltmcelik93@gmail.com");
            mimeMessage.From.Add(mailBoxAddressFrom);

            var mailBoxAddressTo = new MailboxAddress("Sayın Kullanıcı", createMailDTO.ReceiverMail);
            mimeMessage.To.Add(mailBoxAddressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = createMailDTO.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createMailDTO.Subject;
            var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("mltmcelik93@gmail.com", "ndcgzpgkdrfiipmc");

            client.Send(mimeMessage);
            client.Disconnect(true);
            return NoContent();
        }
    }
}