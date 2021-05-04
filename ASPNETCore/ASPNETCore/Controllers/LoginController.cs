using ASPNETCore.Base;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController<Parameter, ParameterRepository, int>
    {
        private readonly ParameterRepository parameterRepository;
        private IConfiguration _config;
        public LoginController(ParameterRepository parameterRepository) : base(parameterRepository)
        {
            this.parameterRepository = parameterRepository;

        }

        [HttpGet("Authenticate")]
        public ActionResult GetRegister(Parameter entity)
        {
            try
            {
                var get = parameterRepository.Authenticate(entity);
                if(get == true)
                {
                    return Ok(get);
                }
                return Forbid("Password or Name is wrong");

            }
            catch (Exception e)
            {
                return NotFound(e.InnerException);
            }
        }
    }
}
