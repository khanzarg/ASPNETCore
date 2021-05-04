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
using System.Net;
using System.Net.Mail;
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
            try 
            {
                var user = context.Accounts.SingleOrDefault(e => e.Email == account.Email);
                var passwordCheck = BCrypt.Net.BCrypt.Verify(account.Password, user.Password);
                if (user != null && passwordCheck)
                {
                    if (user.Role == "Admin") 
                    {
                        var jwt = new JwtService(_config);
                        var token = jwt.GenerateSecurityToken(account.Email, account.Password);
                        return Ok("Successfully login as Admin.\nHere's your token: " + token);
                    }
                    return Ok("Login successful.");
                    
                }
                return BadRequest("Failed to login. Your email and password are not match.");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }

        }

        [Authorize]
        [HttpPost]
        [Route("changepassword")]
        public ActionResult ChangePassword(string email, string oldPassword, string newPassword) 
        {
            try 
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
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
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

        [HttpPost]
        [Route("forgotpassword")]
        public ActionResult ForgotPassword(string email)
        {
            try
            {
                //var email = Request.Headers["email"].ToString();
                var userExisting = context.Accounts.SingleOrDefault(e => e.Email == email);
                string resetCode = Guid.NewGuid().ToString();
                var time24 = DateTime.Now.ToString("HH:mm:ss");
                if (userExisting.Email == email)
                {
                    //create token
                    var jwt = new JwtService(_config);
                    var token = jwt.GenerateSecurityToken(userExisting.Email, userExisting.Password);
                            
                    //Sending email
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential("aninsabrina17@gmail.com", "yulisulasta");
                    MailMessage m = new MailMessage();
                    m.From = new MailAddress("aninsabrina17@gmail.com");
                    m.To.Add(new MailAddress(email));
                    m.Subject = "Reset Password " + time24;
                    m.IsBodyHtml = false;
                    m.Body = "Hi " + "\nThis is your reset code for your account. " 
                        + resetCode + "\nReset link: https://localhost:44320/api/account/resetpassword \nToken: " + token + "\n Thank You";
                    smtp.Send(m);
                    return Ok("Please check your email.");
                }
                return BadRequest("Email not found.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPost]
        [Route("resetpassword")]
        public ActionResult ResetPassword(string email, string newPassword, string confirmPassword)
        {
            try
            {
                var userExisting = context.Accounts.SingleOrDefault(e => e.Email == email);
                if (userExisting.Email == email)
                {
                    if (newPassword == confirmPassword)
                    {
                        userExisting.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                        var save = context.SaveChanges();
                        if (save > 0)
                        {
                            return Ok("Your password has been changed.");
                        }
                    }
                    return BadRequest("Your confirmation password is incorrect.");
                }
                return BadRequest("Email not found.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }
    }
}
