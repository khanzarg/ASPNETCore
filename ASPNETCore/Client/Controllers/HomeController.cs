
using ASPNETCore.Models;
using ASPNETCore.ViewModels;
using Client.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Client.Controllers
{
    [EnableCors("swapi")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44320/API/")
        };

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

        public HttpStatusCode Create(Register register)
        {
            var myContent = JsonConvert.SerializeObject(register);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseTask = client.PostAsync("Accounts/Register", byteContent);
            responseTask.Wait();
            return responseTask.Result.StatusCode;
        }

        public JsonResult GetEmployee()
        {
            IEnumerable<Employee> employees = null;
            var responseTask = client.GetAsync("Employee");
            responseTask.Wait();
            var result = responseTask.Result;
            // status code
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                readTask.Wait();
                employees = readTask.Result;
            }

            return Json(employees);
        }

        public JsonResult GetEmployeeById(int id)
        {
            //IEnumerable<Employee> employees = null;
            var responseTask = client.GetAsync($"Employee/{id}");
            responseTask.Wait();
            var result = responseTask.Result;
            var apiResponse = result.Content.ReadAsStringAsync();

            return Json(apiResponse.Result);
        }

        public HttpStatusCode Delete(int id)
        {
            var responseTask = client.DeleteAsync($"Employee/{id}");
            responseTask.Wait();
            return responseTask.Result.StatusCode;
        }

        public HttpStatusCode Update(Employee employee)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var responseTask = client.PutAsync($"Employee", content);
            responseTask.Wait();
            return responseTask.Result.StatusCode;
        }

    }
}
