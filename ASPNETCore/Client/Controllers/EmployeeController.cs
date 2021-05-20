using ASPNETCore.Models;
using ASPNETCore.ViewModels;
using Client.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Client.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
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
        public Employee Edit(int id)
        {
            var client = new HttpClient();
            var response = client.GetAsync("https://localhost:44320/api/employee/" + id).Result;
            var apiResponse = response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Employee>(apiResponse.Result);

            return data;
            
        }

        [HttpDelete]
        public HttpStatusCode Delete(int id)
        {
            var client = new HttpClient();
            var response = client.DeleteAsync("https://localhost:44320/api/employee/" + id).Result;
            return response.StatusCode;
        }

        [HttpPost]
        public HttpStatusCode Update(AddEmployeeVM employee)
        {
            var client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var result = client.PutAsync("https://localhost:44320/api/employee", content).Result;
            return result.StatusCode;
        }
    }
}
