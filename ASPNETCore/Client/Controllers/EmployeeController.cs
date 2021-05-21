using ASPNETCore.Models;
using Client.View_Models;
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
        public HttpStatusCode Insert(EmployeeVM employee)
        {
            var client = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:44320/api/employee", stringContent);
            response.Wait();
            var result = response.Result;
            return result.StatusCode;
        }

        //[HttpGet]
        //public ActionResult GetById(int id)
        //{
        //    var client = new HttpClient();
        //    var response = client.GetAsync("https://localhost:44320/api/employee/" + id).Result;
        //    var apiResponse = response.Content.ReadAsStringAsync();
        //    var jsn = JsonConvert.DeserializeObject<Employee>(apiResponse.Result);
        //    return PartialView("GetById", jsn);
        //}
        [HttpGet]
        public Employee GetById(int id)
        {
            var client = new HttpClient();
            var response = client.GetAsync("https://localhost:44320/api/employee/" + id).Result;
            var apiResponse = response.Content.ReadAsStringAsync();
            var jsn = JsonConvert.DeserializeObject<Employee>(apiResponse.Result);
            return jsn;
        }

        //[HttpGet]
        //public JsonResult GetById(int id)
        //{
        //    var client = new HttpClient();
        //    var responseTask = client.GetAsync("https://localhost:44320/api/employee/" + id);
        //    responseTask.Wait();
        //    var result = responseTask.Result;
        //    var apiResponse = result.Content.ReadAsStringAsync();

        //    return Json(apiResponse.Result);
        //}

        [HttpDelete]
        public HttpStatusCode Delete(int id)
        {
            var client = new HttpClient();
            var response = client.DeleteAsync("https://localhost:44320/api/employee/" + id);
            response.Wait();
            var result = response.Result; 
            return result.StatusCode;
        }

        [HttpPut]
        public HttpStatusCode Update(EmployeeVM employee)
        {
            var client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var response = client.PutAsync("https://localhost:44320/api/employee/", content);
            response.Wait();
            var result = response.Result;
            return result.StatusCode;
        }
    }
}
