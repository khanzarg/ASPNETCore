using ASPNETCore.Base;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : BaseController<EmployeeRole, EmployeeRoleRepository, int>
    {
        private readonly EmployeeRoleRepository employeeRoleRepository;
        public EmployeeRoleController(EmployeeRoleRepository employeeRoleRepository) : base(employeeRoleRepository)
        {
            this.employeeRoleRepository = employeeRoleRepository;
        }
    }
}
