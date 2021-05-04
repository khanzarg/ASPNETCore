using ASPNETCore.Base;
using ASPNETCore.Handlers;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class RoleController : BaseController<Role, RoleRepository, int>
    {
        private readonly RoleRepository roleRepository;
        private readonly SimpleAuthentication simpleAuthentication;
        private readonly ILogger<RoleController> logger;
        public RoleController(RoleRepository roleRepository, SimpleAuthentication simpleAuthentication, ILogger<RoleController> logger ) : base(roleRepository)
        {
            this.roleRepository = roleRepository;
            this.simpleAuthentication = simpleAuthentication;
            this.logger = logger;
        }

        [HttpGet("CheckRole")]
        public string CheckRole()
        {
            var applicationHeader = Request.Headers["Application"].ToString();
            var tokenHeader = Request.Headers["Token"].ToString();
            var result = simpleAuthentication.Check(applicationHeader, tokenHeader);
            if (result)
            {

                return "Data Berhasil Diambil";

            }
            return "Authentication Failed";
        }
    }
}
