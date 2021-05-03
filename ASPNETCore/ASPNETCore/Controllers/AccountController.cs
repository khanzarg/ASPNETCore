using ASPNETCore.Base;
using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly MyContext context;
        private IConfiguration _config;
        public AccountController(AccountRepository accountRepository, MyContext context, IConfiguration config) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.context = context;
            _config = config;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register(Account account)
        {
            try
            {
                var userExists = context.Accounts.SingleOrDefault(e=>e.Email == account.Email);
                if (userExists != null) 
                {
                    return BadRequest("User already exists.");
                }
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                var result = accountRepository.Post(account) > 0 ? (ActionResult)Ok("Account has been created.") : BadRequest("User creation failed.");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(Account account) 
        {
            var user = context.Accounts.SingleOrDefault(e => e.Email == account.Email);
            var passwordCheck = BCrypt.Net.BCrypt.Verify(account.Password, user.Password);
            if (user != null && passwordCheck) 
            {
                var jwt = new JwtService(_config);
                var token = jwt.GenerateSecurityToken(account.Email, account.Password);
                return Ok(token);
            }
            return BadRequest("Failed to login.");
        }

        [Authorize]
        [HttpPost]
        [Route("changepassword")]
        public ActionResult ChangePassword(string email, string oldPassword, string newPassword) 
        {
            var user = context.Accounts.SingleOrDefault(e => e.Email == email);
            var passwordCheck = BCrypt.Net.BCrypt.Verify(oldPassword, user.Password);
            if (user != null && passwordCheck)
            {
                var newPass = BCrypt.Net.BCrypt.HashPassword(newPassword);
                user.Password = newPass;
                var save = context.SaveChanges();
                if (save > 0)
                {
                    return Ok("Password has been changed.");
                }
            }
            return BadRequest("Your password is incorrect.");

            //var user = context.Accounts.SingleOrDefault(e => e.Email == account.Email);
            //var passwordCheck = BCrypt.Net.BCrypt.Verify(account.Password, user.Password);
            //if (user != null && passwordCheck)
            //{
            //    var newPass = BCrypt.Net.BCrypt.HashPassword(newPassword);
            //    user.Password = newPass;
            //    var save = context.SaveChanges();
            //    if (save > 0) 
            //    {
            //        return Ok("Password has been changed.");
            //    }

            //}
            //return BadRequest("Your password is incorrect.");
        }




    }
}
