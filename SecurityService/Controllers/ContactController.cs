using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarServiceWebsite.Controllers
{
    public class ContactController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Send_Mail() {
            var firstname = Request.Form["firstname"];
            var lastname = Request.Form["lastname"];
            var email = Request.Form["email"];
            var service = Request.Form["service"];
            var message = Request.Form["message"];
            //Send Mail
            var senderEmail = new MailAddress("tranphuoc4511@gmail.com", "Star Security");
            var receiverEmail = new MailAddress(email, "Receiver");
            var password = "Cf123456789";
            var sub = "Sent request success.";
            var body = "Hi! " +
                firstname + " " + lastname+ "\n" +
                "Your service: " + service+ "\n" +
                "We've received your message. We will contact you as soon as possible. Thanks for contacting us \n" +
                " (NO REPLY !!)";
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
            return Json("Success");
        }
    }
}
