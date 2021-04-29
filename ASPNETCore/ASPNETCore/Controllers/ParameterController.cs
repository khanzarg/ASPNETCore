using ASPNETCore.Base;
using ASPNETCore.Handlers;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
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
    public class ParameterController : BaseController<Parameter, ParameterRepository, int>
    {
        private readonly ParameterRepository parameterRepository;
        private readonly SimpleAuthentication simpleAuthentication;

        public ParameterController(ParameterRepository parameterRepository, SimpleAuthentication simpleAuthentication) : base(parameterRepository)
        {
            this.parameterRepository = parameterRepository;
            this.simpleAuthentication = simpleAuthentication;
        }
    }
}
