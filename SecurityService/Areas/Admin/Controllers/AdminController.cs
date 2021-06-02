﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Hosting;

namespace SecurityService.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private IHostingEnvironment _env;

        public AdminController(IHostingEnvironment env)
        {
            _env = env;
        }
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
        public async Task<JsonResult> UploadImageEmp()
        {
            var a = "";
            var dir = _env.ContentRootPath;
            foreach (var formfile in Request.Form.Files)
            {
                a = formfile.FileName;
            }
            using (var fileStream = new FileStream(Path.Combine(dir + "/wwwroot/img/EmployeeImg/", a), FileMode.Create, FileAccess.Write))
            {
                foreach (var formfile in Request.Form.Files)
                {
                    formfile.CopyTo(fileStream);
                }
            }
            return Json("success");
        }
        public async Task<JsonResult> UploadImageService()
        {
            var a = "";
            var dir = _env.ContentRootPath;
            foreach (var formfile in Request.Form.Files)
            {
                a = formfile.FileName;
            }
            using (var fileStream = new FileStream(Path.Combine(dir + "/wwwroot/img/", a), FileMode.Create, FileAccess.Write))
            {
                foreach (var formfile in Request.Form.Files)
                {
                    formfile.CopyTo(fileStream);
                }
            }
            return Json("success");
        }
    }
}
