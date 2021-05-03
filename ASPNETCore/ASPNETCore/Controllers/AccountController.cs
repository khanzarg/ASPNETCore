using ASPNETCore.Base;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AccountController : BaseController<Account, AccountRepository, int>
    {
        private readonly AccountRepository accountRepository;
        private IConfiguration _config;
        public AccountController(AccountRepository accountRepository, IConfiguration config) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            _config = config;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register(Account account)
        {
            try
            {
                //var userExists = accountRepository.
                var result = accountRepository.Post(account) > 0 ? (ActionResult)Ok("Account has been created.") : BadRequest("User creation failed.");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

    }
}
