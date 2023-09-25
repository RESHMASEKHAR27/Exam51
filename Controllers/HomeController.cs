using Exam51.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;

namespace Exam51.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Form std)
        {
            if (!ModelState.IsValid)
            {
                return View(std);
            }
            var mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse(std.From));
            mail.To.Add(MailboxAddress.Parse(std.To));
            mail.Subject = $"Subject:{std.Subject}";
            mail.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = $"From:{std.From}"+"\n" +$"To:{std.To}"+"\n" + $"subject:{std.Subject}" + "\n" + $"Body:{std.Body}"
            };

            var smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("reshmasekhar27@gmail.com", "isdaelbbtbrgfkun");
            smtp.Send(mail);
            smtp.Disconnect(true);

            
            return RedirectToAction("Privacy");
        }

        public IActionResult Privacy()
        {
            ViewBag.Content = "Successfully Send";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}