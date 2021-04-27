using ASPNETCore.Models;
using ASPNETCore.Repository.Data;
using ASPNETCore.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();

        private IGenericRepository<Employee> repository = null;
        public EmployeeController()
        {
            this.repository = new GeneralRepository<Employee>();
        }
        //public EmployeeController(IGenericRepository<Employee> repository)
        //{
        //    this.repository = repository;
        //}


        [HttpPost]
        [Route("api/Employees")]
        public ActionResult Post(Employee employee)
        {
            employeeRepository.InsertEmployee(employee);
            return Ok("Data Inserted!!!");
        }

        [HttpGet]
        [Route("api/Employees")]
        public ActionResult Get()
        {
            var get = employeeRepository.GetEmployees();
            if (get.Count() == 0)
            {
                return BadRequest("Data Not Found");
            }
            return Ok(get);

        }

        [HttpGet]
        [Route("api/Employee/{id}")]
        public ActionResult GetById(int id)
        {
            var get = employeeRepository.GetEmployeeById(id);
            if (get == null)
            {
                return BadRequest("Data Not Found");
            }
            return Ok(get);
        }


        [HttpDelete]
        [Route("api/Departments/{id}")]
        public ActionResult Delete(int id)
        {
            employeeRepository.DeleteEmployee(id);
            return Ok("Data Deleted!!!");

        }

        [HttpPut]
        [Route("api/Departments/{id}")]
        public ActionResult Update(Employee employee)
        {
            employeeRepository.UpdateEmployee(employee);
            return Ok("Data Updated");

        }
    }
}
