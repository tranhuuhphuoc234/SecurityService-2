using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecurityService.Controllers
{
    public class CareerController : Controller
    {
        private IHostingEnvironment _env;
        public CareerController(IHostingEnvironment env)
        {
            _env = env;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult testUpload()
        {
            using (var stream = System.IO.File.Create("123"))
            {

            }
            return Json("success");
        }

        [HttpPost]
        public async Task<JsonResult> UploadCV()
        {
            var a = "";
            var dir = _env.ContentRootPath;
            foreach (var formfile in Request.Form.Files)
            {
                a = formfile.FileName;
            }
            using (var fileStream = new FileStream(Path.Combine(dir + "/wwwroot/img/CV/", a), FileMode.Create, FileAccess.Write))
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
