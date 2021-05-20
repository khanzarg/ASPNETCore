using ASPNETCore.Base;
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
    public class LoginModelsController : BaseController<LoginModel, LoginModelRepository, int>
    {
        private LoginModelRepository repository;

        public LoginModelsController(LoginModelRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
