using ASPNETCore.Base;
using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Repositories.Interface;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee, EmployeeRepository, int>
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly IGenericDapper _dapper;
        public EmployeeController(EmployeeRepository employeeRepository, IGenericDapper dapper) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            _dapper = dapper;
        }

        [HttpGet]
        [Route("gender/{tahun}")]
        public IActionResult GetGenders(int tahun)
        {
            var dbparam = new DynamicParameters();
            dbparam.Add("tahun", tahun, DbType.Int32);
            dynamic result = _dapper.GetAll<dynamic>(
                "[dbo].[SP_GetGenders]",
                dbparam,
                CommandType.StoredProcedure
                );
            return Ok(result);
        }


        [HttpGet]
        [Route("tahun")]
        public IActionResult GetYear()
        {
            var dbparam = new DynamicParameters();
            dbparam.Add("tahun", DbType.Int32);
            dynamic result = _dapper.GetAll<dynamic>(
                "[dbo].[SP_GetYearBirthDate]",
                dbparam,
                CommandType.StoredProcedure
                );
            return Ok(result);
        }





    }

    
}
