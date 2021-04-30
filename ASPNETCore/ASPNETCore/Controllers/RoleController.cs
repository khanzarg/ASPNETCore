using ASPNETCore.Base;
using ASPNETCore.Handlers;
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
    public class RoleController : BaseController<Role, RoleRepository, int>
    {
        private readonly RoleRepository roleRepository;
        private readonly SimpleAuthentication simpleAuthentication;

        public RoleController(RoleRepository roleRepository, SimpleAuthentication simpleAuthentication) : base(roleRepository)
        {
            this.roleRepository = roleRepository;
            this.simpleAuthentication = simpleAuthentication;
        }

        [HttpGet("CheckRole")]
        public string CheckRole()
        {
            var applicationHeader = Request.Headers["Application"].ToString();
            var tokenHeader = Request.Headers["Token"].ToString();
            var result = simpleAuthentication.Check(applicationHeader, tokenHeader);
            if (result)
            {
                return "Authorize";
            }
            return "Authentication Failed";
        }
    }
}
