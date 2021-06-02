using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SecurityService.Controllers
{
    public class ServicesController : Controller
    {
       
        public async Task<IActionResult> Index(string name)
        {
            Models.View.Service pro = new Models.View.Service();
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54396/api/");

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("services/getService/" + name);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    pro = JsonConvert.DeserializeObject<Models.View.Service>(EmpResponse);
                    ViewData["service"] = pro;
                }
                return View();
            }
        }
        public IActionResult Show()
        {
            return View();
        }
    }
}
