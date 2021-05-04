using ASPNETCore.Base;
using ASPNETCore.Context;
using ASPNETCore.Handlers;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Services;
using System.IO;
using System.Net;
using System.Net.Mail;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, int>
    {
        private readonly AccountRepository accountRepository;
        private readonly LoginAuthentication loginAuthentication;
        private readonly IConfiguration config;

        public AccountsController(AccountRepository accountRepository, LoginAuthentication loginAuthentication, IConfiguration config) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.loginAuthentication = loginAuthentication;
            this.config = config;
        }

        [HttpPost("register")]
        public ActionResult Register(Account account)
        {
            try
            {
                // Bcrypt
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(account.Password);
                account.Password = passwordHash;
                // Insert to account
                var result = accountRepository.Post(account) > 0 ? (ActionResult)Ok("Data has been successfully inserted.") : BadRequest("Data can't be inserted");
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost("login")]
        public ActionResult Login()
        {
            // get value from header
            string hEmail = Request.Headers["email"];
            string hPassword = Request.Headers["password"];
            
            // login authentication
            var result = loginAuthentication.Authenticate(hEmail, hPassword);
            if (result)
            {
                // cari role berdasarkan email
                var role = accountRepository.GetByEmail(hEmail).Role;
                // create jwt token
                var jwt = new JwtService(config);
                string token = jwt.GenerateLoginToken(hEmail, role);
                return Ok(token);
            }
            return BadRequest("email or password is not match");
        }

        [HttpPut("change-password")]
        [Authorize]
        public ActionResult ChangePassword()
        {
            // get value from header
            string id = Request.Headers["id"];
            string currentPassword = Request.Headers["current-password"];
            string newPassword = Request.Headers["new-password"];
            string verifiyPassword = Request.Headers["verifiy-password"];
            
            // find model by id model
            var model = accountRepository.GetById(Int32.Parse(id));
            string getCurrentPassword = model.Password;
          

            // nanti bikin function
            if (BCrypt.Net.BCrypt.Verify(currentPassword, getCurrentPassword))
            {
                if (newPassword == verifiyPassword)
                {
                    // BCrypt
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                    model.Password = passwordHash;
                    // update model
                    var result = accountRepository.Put(model) > 0 ? (ActionResult)Ok("Data has been successfully updated.") : BadRequest("Data can't be updated.");
                    return Ok(result);
                }
                return BadRequest("Failed to verify password");
            }
            return BadRequest("Current Password berbeda");
        }
        
        [HttpPost("forgot-password")]
        public ActionResult ForgotPassword()
        {
            string hemail = Request.Headers["email"];
            var jwt = new JwtService(config);
            string token = jwt.GenerateSecurityToken(hemail);
            // tambahin smptclient

            return Ok("Https://localhost:44320/api/Accounts/reset-password?token=" + token);
        }

        [Authorize]
        [HttpPost("reset-password")]
        public ActionResult ResetPassword()
        {
            string token = Request.Query["token"];
            
            // read jwt
            var jwt = new JwtSecurityTokenHandler();
            var jwtRead = jwt.ReadJwtToken(token);
            
            // new password
            string newPassword = Request.Headers["new-password"];
            string verifyPassword = Request.Headers["verify-password"];

            if (newPassword == verifyPassword)
            {
                var email = jwtRead.Claims.First(claim => claim.Type == "email").Value;
                var model = accountRepository.GetByEmail(email);
                
                // Bcrypt
                string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                model.Password = newPasswordHash;

                // Update
                var result = accountRepository.Put(model) > 0 ? (ActionResult)Ok("Data has been successfully updated.") : BadRequest("Data can't be updated.");
                return Ok(result);
            }
            return BadRequest("password is not match");

          
            
          
        }

    }
}
