using ASPNETCore.Models;
using Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public HttpStatusCode AddEmployee(AddEmployeeVM employee)
        {
            var client = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var result = client.PostAsync("https://localhost:44320/api/employee", stringContent).Result;
            return result.StatusCode;
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var client = new HttpClient();
            var response = client.GetAsync("https://localhost:44320/api/employee/" + id);
            response.Wait();
            var result = response.Result;
            var apiResponse = result.Content.ReadAsStringAsync();

            return Json(apiResponse.Result);
        }

        [HttpDelete]
        public HttpStatusCode Delete(int id)
        {
            var client = new HttpClient();
            var response = client.DeleteAsync("https://localhost:44320/api/employee/" + id).Result;
            return response.StatusCode;
        }

        [HttpPut]
        public HttpStatusCode Update(AddEmployeeVM employee)
        {
            var client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var result = client.PutAsync("https://localhost:44320/api/employee", content);
            return result.Result.StatusCode;
        }
    }
}
