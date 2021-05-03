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

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountRepository, int>
    {

        private AccountRepository accountRepository;
        private MyContext context;
        private IConfiguration _config;

        public AccountController(AccountRepository accountRepository, MyContext context, IConfiguration _config) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.context = context;
            this._config = _config;
        }

        [HttpPost("Register/")]
        public ActionResult PostRegister(Account account)
        {
            try
            {
                string passwordHash = BC.HashPassword(account.Password);
                account.Password = passwordHash;
                var result = accountRepository.Post(account) > 0 ? (ActionResult)Ok("Data has been successfully inserted.") : BadRequest("Data can't be inserted");
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
            try
            {
                string email = Request.Headers["Email"].ToString();
                string password = Request.Headers["Password"].ToString();
                // get account from database
                var foundAccount = context.Accounts.SingleOrDefault(account => account.Email == email);
                if (foundAccount == null || !BC.Verify(password, foundAccount.Password))
                {
                    // authentication failed
                    return NotFound("Email / Password Wrong");
                }
                else
                {
                    // authentication successful, generate token
                    var jwt = new JwtService(_config);
                    var token = jwt.GenerateSecurityToken(email);
                    return Ok(token);
                    
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost("Forget-Password")]
        public ActionResult ForgetPassword()
        {
            string email = Request.Headers["Email"].ToString();
            var foundAccount = context.Accounts.Where(account => account.Email == email).FirstOrDefault();
            if (foundAccount == null)
            {
                return NotFound("Email Not Found");
            }
            else
            {
                //var jwt = new JwtService(_config);
                //var token = jwt.GenerateSecurityToken(email);
                //return Ok("https://localhost:44320/api/Account/Reset-Password/" + token);

                foundAccount.Password = "passwordbaru";
                context.Entry(foundAccount).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                var user = new SmtpClient("smtp.gmail.com", 465)
                {
                    Credentials = new NetworkCredential("aninsabrina17@gmail.com", "yulisulasta"),
                    EnableSsl = true,
                    UseDefaultCredentials = false
                    
            };
               
                user.Send("aninsabrina17@gmail.com", foundAccount.Email, "Reset Password Request", "Your New Password : passwordbaru");
                
                return Ok("request sent");
            }
            

        }

        //[HttpPost("Reset-Password")]
        //public ActionResult ResetPassword()
        //{
            
        //}

        [HttpPost("Change-Password")]
        public ActionResult ChangePassword()
        {
            string email = Request.Headers["Email"].ToString();
            string currentPassword = Request.Headers["CurrentPassword"].ToString();
            string newPassword = Request.Headers["NewPassword"].ToString();
            string confirmPassword = Request.Headers["ConfirmPassword"].ToString();
            var foundAccount = context.Accounts.Where(account => account.Email == email).FirstOrDefault();

            if(foundAccount == null || !BC.Verify(currentPassword, foundAccount.Password))
            {
                return NotFound("Wrong Email / Current Password");
            }
            else if(newPassword != confirmPassword)
            {
                return BadRequest("New Password & Confirm Password Must Same");
            }
            else
            {
                string passwordHash = BC.HashPassword(newPassword);
                foundAccount.Password = passwordHash;
                var result = accountRepository.Put(foundAccount) > 0 ? (ActionResult)Ok("Data has been successfully updated.") : BadRequest("Data can't be updated.");
                return result;
            }
            
        }
    }
}
