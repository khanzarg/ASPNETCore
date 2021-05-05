using ASPNETCore.Base;
using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Services;
using ASPNETCore.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ASPNETCore.ViewModels;

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
        public ActionResult Register(Register register)
        {
            try
            {
                var userExists = context.Employees.SingleOrDefault(e=>e.Email == register.Email);
                if (userExists != null) 
                {
                    return BadRequest("User already exists.");
                }
                register.Password = Hash.HashPassword(register.Password);

                //var result = accountRepository.Post(register) > 0 ? (ActionResult)Ok("Account has been created.") : BadRequest("User creation failed.");
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(Account account) 
        {
            //try 
            //{
            //    var user = context.Accounts.SingleOrDefault(a => a.Email == account.Email);
            //    var role = context.Accounts.SingleOrDefault(a => a.Role.Id == user.Id);
            //    var passwordCheck = Hash.ValidatePassword(account.Password, user.Password);
            //    if (user != null && passwordCheck)
            //    {
            //        var jwt = new JwtService(_config);
            //        var token = jwt.GenerateSecurityToken(account.Email, account.Password, role.Role.Name);
            //        return Ok(token);
            //    }
            //    return BadRequest("Failed to login. Your email and password are not match.");
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e.InnerException);
            //}
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("changepassword")]
        public ActionResult ChangePassword(string email, string oldPassword, string newPassword) 
        {
            //try 
            //{
            //    var user = context.Accounts.SingleOrDefault(a => a.Email == email);
            //    var passwordCheck = Hash.ValidatePassword(oldPassword, user.Password);
            //    if (user != null && passwordCheck)
            //    {
            //        var newPass = Hash.HashPassword(newPassword);
            //        user.Password = newPass;
            //        var save = context.SaveChanges();
            //        if (save > 0)
            //        {
            //            return Ok("Password has been changed.");
            //        }
            //    }
            //    return BadRequest("Your password is incorrect.");
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e.InnerException);
            //}
            return Ok();
        }

        [HttpPost]
        [Route("forgotpassword")]
        public ActionResult ForgotPassword(string email)
        {
            //try
            //{
            //    //var email = Request.Headers["email"].ToString();
            //    var userExisting = context.Accounts.SingleOrDefault(a => a.Email == email);
            //    var role = context.Roles.SingleOrDefault(r => r.Id == userExisting.Role.Id);
            //    string resetCode = Guid.NewGuid().ToString();
            //    if (userExisting.Email == email)
            //    {
            //        //create token
            //        var jwt = new JwtService(_config);
            //        var token = jwt.GenerateSecurityToken(userExisting.Email, userExisting.Password, role.Name);

            //        //Sending email
            //        var sendEmail = new SendEmail(context);
            //        sendEmail.SendForgotPassword(token, resetCode, email);
            //        return Ok("Please check your email.");
            //    }
            //    return BadRequest("Email not found.");
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e.Message);
            //}
            return Ok();
        }
        [Authorize]
        [HttpPost]
        [Route("resetpassword")]
        public ActionResult ResetPassword(string email, string newPassword, string confirmPassword)
        {
            //try
            //{
            //    var userExisting = context.Accounts.SingleOrDefault(e => e.Email == email);
            //    if (userExisting.Email == email)
            //    {
            //        if (newPassword == confirmPassword)
            //        {
            //            userExisting.Password = Hash.HashPassword(newPassword);
            //            var save = context.SaveChanges();
            //            if (save > 0)
            //            {
            //                return Ok("Your password has been changed.");
            //            }
            //        }
            //        return BadRequest("Your confirmation password is incorrect.");
            //    }
            //    return BadRequest("Email not found.");
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e.Message);
            //} 
            return Ok();
        }
    }
}
