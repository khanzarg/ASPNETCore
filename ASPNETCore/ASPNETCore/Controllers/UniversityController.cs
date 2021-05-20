using ASPNETCore.Base;
using ASPNETCore.Handlers;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("MyPolicy")]
    [ApiController]
    public class UniversitiesController : BaseController<University, UniversityRepository, int>
    {
        private readonly UniversityRepository universityRepository;
        private readonly SimpleAuthentication simpleAuthentication;
        public UniversitiesController(UniversityRepository universityRepository, SimpleAuthentication simpleAuthentication) : base(universityRepository)
        {
            this.universityRepository = universityRepository;
            this.simpleAuthentication = simpleAuthentication;
        }

        [HttpGet("CheckUni/")]
        public string CheckUniversity()
        {
            var application = Request.Headers["Application"].ToString();
            var token = Request.Headers["Token"].ToString();

            var isAuth = simpleAuthentication.Check(application, token);

            if (isAuth)
            {
                return "AUTHORIZED";
            }
            return "UNAUTHORIZED";
        }
    }
}
