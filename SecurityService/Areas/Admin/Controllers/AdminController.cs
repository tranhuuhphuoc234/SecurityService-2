using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SecurityService.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All_Infor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send_mail_client()
        {
            var email = Request.Form["email"];
            var name_client = Request.Form["name_client"];
            var name_service = Request.Form["name_service"];
            var senderEmail = new MailAddress("tranphuoc4511@gmail.com", "Star Security");
            var receiverEmail = new MailAddress(email, "Receiver");
            var password = "Cf123456789";
            var sub = "Sent request success.";
            var body = "Hi " + name_client + "." + "Welcome to our service.\n"+
                "We see you want to hire our " + name_service + " service ?\n" +
                "Client service time : from 2 to 6 . You can come any time.\n "+
                "Location :  Aptech, HCM, Viet Nam.\n"+
                "\nThank you for using our service . ^-^ \n(NO REPLY !!)";
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
