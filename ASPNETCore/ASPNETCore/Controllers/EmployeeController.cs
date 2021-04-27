using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repository.Data;
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
        private MyContext context;
        private GeneralRepository<Employee> employeeRepository = null;
        public EmployeeController()
        {
            this.employeeRepository = new GeneralRepository<Employee>();
        }
        //public EmployeeController(IGenericRepository<Employee> repository)
        //{
        //    this.repository = repository;
        //}


        [HttpPost]
        [Route("api/Employees")]
        public ActionResult Post(Employee employee)
        {
            employeeRepository.Post(employee);
            return Ok("Data Inserted!!!");
        }

        [HttpGet]
        [Route("api/Employees")]
        public ActionResult Get()
        {
            var get = employeeRepository.GetAll();
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
            var get = employeeRepository.GetById(id);
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
            employeeRepository.Delete(id);
            return Ok("Data Deleted!!!");

        }

        [HttpPut]
        [Route("api/Departments/{id}")]
        public ActionResult Update(Employee employee)
        {
            employeeRepository.Put(employee);
            return Ok("Data Updated");

        }
    }
}
