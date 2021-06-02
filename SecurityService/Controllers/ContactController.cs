using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using FluentEmail.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using SecurityService.Models.Utils;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarServiceWebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMailSender _mailSender;

        public ContactController(IMailSender mailSender) 
        {
            _mailSender = mailSender;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Send_Mail([FromServices] IFluentEmail mailer) {
            var email = Request.Form["email"];
            _mailSender.SendHtmlGamil(email, "phuoc");
             return Json("Success");
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz01234567899876543210";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public IActionResult Check_Mail() {
            var email = Request.Form["email"];
            var senderEmail = new MailAddress("tranphuoc4511@gmail.com", "Star Security");
            var receiverEmail = new MailAddress(email, "Receiver");
            var password = "Cf123456789";
            var sub = "Verify Email";
            var code = RandomString(7);
            var body = "Your Code: " + code;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = sub,
                Body = body
            })
            {
                smtp.Send(mess);
            }
            return Json(code);
        }
        public void BuildEmailTemplate(int regId) 
        {
        }
        public ActionResult formemail()
        {
            return View();
        }
    }
}
