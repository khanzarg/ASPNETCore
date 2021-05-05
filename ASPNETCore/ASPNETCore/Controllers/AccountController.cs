using BC = BCrypt.Net.BCrypt;
using ASPNETCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.Base;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Context;
using Microsoft.Extensions.Configuration;
using ASPNETCore.Services;
using System.Net.Mail;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using ASPNETCore.Handlers;
using ASPNETCore.ViewModels;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountRepository, int>
    {
        private SendEmail sendEmail;
        private AccountRepository accountRepository;
        private MyContext context;
        private IConfiguration _config;

        public AccountController(AccountRepository accountRepository, MyContext context, IConfiguration _config, SendEmail sendEmail) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.context = context;
            this._config = _config;
            this.sendEmail = sendEmail;
        }


        [HttpGet("GetAll/")]
        //[Route("api/")]
        public new ActionResult Get()
        {
            var get = accountRepository.GetAll();
            if (get.Count() == 0)
            {
                return BadRequest("Data Not Found");
            }
            return Ok(get);

        }


        [HttpPost("Register/")]
        public ActionResult PostRegister(Register register)
        {
            try
            {
                var userExists = context.Employees.SingleOrDefault(Employee => Employee.Email == register.Email);
                string passwordHash = BC.HashPassword(register.Password);
                register.Password = passwordHash;
                var result = accountRepository.Post(register) > 0 ? (ActionResult)Ok("Data has been successfully inserted.") : BadRequest("Data can't be inserted");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
        
        [HttpPost("Login/")]
        public ActionResult Login()
        {
            return Ok();
            //try
            //{
            //    string email = Request.Headers["Email"].ToString();
            //    string password = Request.Headers["Password"].ToString();


            //    // get account from database
            //    var foundAccount = context.Accounts.SingleOrDefault(account => account.Email == email);
            //    if (foundAccount == null || !BC.Verify(password, foundAccount.Password))
            //    {
            //        // authentication failed
            //        return NotFound("Email / Password Wrong");
            //    }
            //    else
            //    {
            //        // authentication successful, generate token
            //        var role = foundAccount.CurrentRoleId.ToString();
            //        var nameRole = foundAccount.Role;
            //        var jwt = new JwtService(_config);
            //        var token = jwt.GenerateSecurityLoginToken(email, role);
            //        return Ok(token);

            //    }
            //}
            //catch (Exception e)
            //{
            //return BadRequest(e.InnerException);
            //}
            
        }

        [HttpPost("Forget-Password")]
        public ActionResult ForgetPassword()
        {
            return Ok();
            //string headerEmail = Request.Headers["Email"].ToString();
            //var foundAccount = context.Accounts.Where(account => account.Email == headerEmail).FirstOrDefault();
            //if (foundAccount == null)
            //{
            //    return NotFound("Email Not Found");
            //}
            //else
            //{
            //    var jwt = new JwtService(_config);
            //    string token = jwt.GenerateSecurityToken(headerEmail);
            //    string url = "https://localhost:44320/api/Account/Reset-Password?Token=";

            //    var sendEmail = new SendEmail(context);
            //    sendEmail.SendForgetPassword(url, token, foundAccount);
            //    return Ok("Please Check Email");

                //var user = new SmtpClient("smtp.gmail.com", 587)
                //{
                //    UseDefaultCredentials = false,
                //    EnableSsl = true,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    Credentials = new NetworkCredential("aninsabrina17@gmail.com", "yulisulasta"),

                //};

                //user.Send("aninsabrina17@gmail.com", foundAccount.Email, "Reset Password Request", $"Link Reset Password : {url}{token}");

                //return Ok("request sent");

                //belum kirim pakai email
                //var jwt = new JwtService(_config);
                //var token = jwt.GenerateSecurityToken(email);
                //return Ok("https://localhost:44320/api/Account/Reset-Password?Token=" + token + "&Email=" + email);
                //return Ok("https://localhost:44320/api/Account/Reset-Password?Token=" + token);
            //}


        }

        [HttpPost("Reset-Password")]
        public ActionResult ResetPassword()
        {
            //var token = Request.Query["Token"].ToString();
            //var email = Request.Query["Email"].ToString();

            //var newPassword = Request.Headers["NewPassword"].ToString();
            //var confirmPassword = Request.Headers["ConfirmPassword"].ToString();

            //var foundAccount = context.Accounts.Where(account => account.Email == email).FirstOrDefault();

            //if (foundAccount == null)
            //{
            //    return NotFound("Wrong Email");
            //}
            //else if (newPassword != confirmPassword)
            //{
            //    return BadRequest("New Password & Confirm Password Must Same");
            //}
            //else if(token != Request.Query["Token"].ToString())
            //{
            //    return Unauthorized();
            //}
            //else
            //{
            //    string passwordHash = BC.HashPassword(newPassword);
            //    foundAccount.Password = passwordHash;
            //    var result = accountRepository.Put(foundAccount) > 0 ? (ActionResult)Ok("Data has been successfully updated.") : BadRequest("Data can't be updated.");
            //    return result;
            //}

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var readToken = tokenHandler.ReadJwtToken(Request.Query["Token"]);

            //var newPassword = Request.Headers["NewPassword"].ToString();
            //var confirmPassword = Request.Headers["ConfirmPassword"].ToString();

            //if(newPassword == confirmPassword)
            //{
            //    var getEmail = readToken.Claims.First(getEmail => getEmail.Type == "email").Value;
            //    var foundAccount = context.Accounts.Where(account => account.Email == getEmail).FirstOrDefault();

            //    if (foundAccount == null)
            //    {
            //        return NotFound("Wrong Email");
            //    }
            //    else
            //    {
            //        string passwordHash = BC.HashPassword(newPassword);
            //        foundAccount.Password = passwordHash;
            //        var result = accountRepository.Put(foundAccount) > 0 ? (ActionResult)Ok("Data has been successfully updated.") : BadRequest("Data can't be updated.");
            //        return result;
            //    }
            //}
            //else
            //{
            //    return BadRequest("New Password & Confirm Password Must Same");
            //}
            return Ok();
        }

        [HttpPost("Change-Password")]
        public ActionResult ChangePassword()
        {
            return Ok();
            //string email = Request.Headers["Email"].ToString();
            //string currentPassword = Request.Headers["CurrentPassword"].ToString();
            //string newPassword = Request.Headers["NewPassword"].ToString();
            //string confirmPassword = Request.Headers["ConfirmPassword"].ToString();
            //var foundAccount = context.Accounts.Where(account => account.Email == email).FirstOrDefault();

            //if(foundAccount == null || !BC.Verify(currentPassword, foundAccount.Password))
            //{
            //    return NotFound("Wrong Email / Current Password");
            //}
            //else if(newPassword != confirmPassword)
            //{
            //    return BadRequest("New Password & Confirm Password Must Same");
            //}
            //else
            //{
            //    string passwordHash = BC.HashPassword(newPassword);
            //    foundAccount.Password = passwordHash;
            //    var result = accountRepository.Put(foundAccount) > 0 ? (ActionResult)Ok("Data has been successfully updated.") : BadRequest("Data can't be updated.");
            //    return result;
            //}
            
        }
    }
}
