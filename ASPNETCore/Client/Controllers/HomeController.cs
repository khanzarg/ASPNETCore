using ASPNETCore.Models;
using ASPNETCore.ViewModels;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace Client.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public async Task<IActionResult> Index()
        //{
        //    List<Register> registerList = new List<Register>();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44320/api/Employee"))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            registerList = JsonConvert.DeserializeObject<List<Register>>(apiResponse);
        //        }
        //    }
        //    return View(registerList);
        //}
        //[HttpPost]
        //public HttpStatusCode Register(Register register)
        //{
        //    var httpClient = new HttpClient();
        //    StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
        //    var result = httpClient.PostAsync("https://localhost:44320/api/Account/register/", content).Result;
        //    return result.StatusCode;
        //}

    }
}
