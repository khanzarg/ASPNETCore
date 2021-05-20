using ASPNETCore.Base;
using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Repositories.Interface;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    
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

        [HttpGet("Gender/{tahun}")]
        public ActionResult GetGenders(int tahun)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("tahun", tahun, DbType.Int32);
            dynamic result = _dapper.GetAll<dynamic>(
                    "[dbo].[SP_GetGenders]",
                    dbparams,
                    CommandType.StoredProcedure
                );
            return Ok(result);
        }

        [HttpGet("Tahun")]
        public ActionResult GetYear()
        {
            int tahun = 0;
            var dbparams = new DynamicParameters();
            dbparams.Add("tahun", tahun, DbType.Int32);
            dynamic result = _dapper.GetAll<dynamic>(
                    "[dbo].[SP_GetYears]",
                    dbparams,
                    CommandType.StoredProcedure
                );
            return Ok(result);
        }
    }
}
