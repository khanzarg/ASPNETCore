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
<<<<<<< HEAD
<<<<<<< Updated upstream
    public class EmployeeRoleController : Controller
=======
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : BaseController<EmployeeRole, EmployeeRoleRepository, int>
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : BaseController<EmployeeRole, EmployeeRoleRepository, int>
>>>>>>> main
=======
>>>>>>> Stashed changes
    {
        private readonly EmployeeRoleRepository employeeRoleRepository;
        public EmployeeRoleController(EmployeeRoleRepository employeeRoleRepository) : base(employeeRoleRepository)
        {
            this.employeeRoleRepository = employeeRoleRepository;
        }
    }
}
