using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SecurityService.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SecurityService.Controllers
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
        /*public async System.Threading.Tasks.Task<IActionResult> Index()
        {
            List<Models.About_us_employee> pro = new List<About_us_employee>();
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:54396/api/");

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("about_us_employee");
                
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    pro = JsonConvert.DeserializeObject<List<Models.About_us_employee>>(EmpResponse);
                    
                }
                TempData["listAbout"] = pro;
            }
             return View();
        }
        */
       
    }
}
