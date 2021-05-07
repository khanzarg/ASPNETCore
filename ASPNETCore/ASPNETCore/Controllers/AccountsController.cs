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
using ASPNETCore.ViewModels;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using ASPNETCore.Repositories;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController  : BaseController<Account, AccountRepository, int>
    {
        private readonly AccountRepository accountRepository;
        private readonly AccountAuthentication Auth;
        private readonly IConfiguration config;
        private readonly MyContext myContext;
        private readonly GeneralDapper dapper;
        public AccountsController(MyContext myContext,GeneralDapper dapper, AccountRepository accountRepository, AccountAuthentication loginAuthentication, IConfiguration config) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.Auth = loginAuthentication;
            this.config = config;
            this.dapper = dapper;
            this.myContext = myContext;
        }

        [HttpPost("register")]
        public ActionResult Register(Register register)
        {
            try
            {
                var dbparams = new DynamicParameters();
                string hashPassword = Auth.Encrypt(register.Password);
                if(Auth.CheckEmail(register.Email))
                {
                    dbparams.Add("Name", register.Name, DbType.String);
                    dbparams.Add("Email", register.Email, DbType.String);
                    dbparams.Add("Password", hashPassword, DbType.String);
                    dbparams.Add("Gender", register.Gender, DbType.String);
                    dbparams.Add("BirthDate", register.BirthDate, DbType.DateTime);
                    dbparams.Add("Phone", register.Phone, DbType.String);
                    dbparams.Add("RoleId", register.RoleId, DbType.Int32);
                    var result = Task.FromResult(dapper.Insert<int>("[dbo].[SP_Register]"
                        , dbparams,
                        commandType: CommandType.StoredProcedure));
                    return Ok(new { Status = "Success", Message = "User has been registered successfully" });
                }
                else
                {
                    return Conflict(new { Status = "Failed", Message = "Email is already exists in database" });
                }
                
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult LoginAcc(Login login)
        {
            try
            {
                bool emailIsExists = Auth.CheckEmail(login.Email);
                if (emailIsExists)
                {
                    bool passwordIsCorrect = Auth.VerifyPassword(login.Email, login.Password);
                    if (passwordIsCorrect)
                    {
                        var dbparams = new DynamicParameters();
                        dbparams.Add("inputEmail", login.Email, DbType.String);
                        var result = Task.FromResult(dapper.Get<dynamic>($"[dbo].[SP_Login]"
                            , dbparams,
                            commandType: CommandType.StoredProcedure)).Result;

                        var jwt = new JwtService(config);
                        var token = jwt.GenerateLogin(result.Name, result.Email, result.Role);

                        return Ok(new { token });
                    }
                    else
                    {
                        return Unauthorized(new { Status = "Failed", Message = "Password is wrong" });
                    }
                }
                else
                {
                    return NotFound("Email is not registered");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("change-password")]
        public ActionResult ChangePassword(ChangePassword changePassword)
        {

            var account = Auth.GetAccount(changePassword.Email);
            var model = Auth.GetAccount(account.Employee.Email);
            string getCurrentPassword = model.Password;

            // nanti bikin function
            if (BCrypt.Net.BCrypt.Verify(changePassword.OldPassword, model.Password))
            {
                model.Password = Auth.Encrypt(changePassword.NewPassword);
                var result = accountRepository.Put(model) > 0 ? (ActionResult)Ok("Password has been changed.") : BadRequest("Data can't be updated.");
                return result;
            }
            return Conflict(new { Status = "Failed", Message = "Old Password is not Correct" });
        }

        [HttpPost("forgot-password")]
        public ActionResult ForgotPassword(string email)
        {
            var parameter = myContext.Parameters.Find(1);
            var sender = parameter.Name;
            var senderPassword = parameter.Value;
            string receiver = Request.Query["email"];

            var user = new SmtpClient("smtp.gmail.com", 587) //bikin 1 handler sendiri
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(sender, senderPassword),
 
            };

            var account = Auth.GetAccount(email);
            if(account != null)
            {
                var jwt = new JwtService(config);
                string token = jwt.GenerateSecurityToken(receiver);
                MailMessage message = new MailMessage(sender, receiver);
                message.Subject = "Reset Password Request";
                message.Body = $" Token : {token}";
                user.Send(message);
                return Ok(new { Status = "Request has been sent", Message ="Please check your email" });
            }
            else
            {
                return NotFound(new { Status = "Request Failed" , Message = "Email is not registered" });
            }
           
        }

        [HttpPost("reset-password")]
        public ActionResult ResetPassword(string newPassword, string JWTtoken)
        {
            string token = Request.Query["JWTtoken"];
            var jwt = new JwtSecurityTokenHandler();
            // read jwt baca isi token
            try
            {
                var jwtRead = jwt.ReadJwtToken(token);
                // new password
                string Password = Request.Query["newPassword"];
                var email = jwtRead.Claims.First(claim => claim.Type == "email").Value;
                var account = Auth.GetAccount(email);
                // Bcrypt
                account.Password = Auth.Encrypt(Password);

                // Update
                var result = accountRepository.Put(account) > 0 ? (ActionResult)Ok("Password has been updated") : BadRequest("Data can't be updated.");
                return result;
            }
            catch (ArgumentException)
            {
                return Unauthorized(new { Status = "Failed", Message = "Link is expired" });
            }
        }

        //[HttpGet("coba")]
        //public ActionResult Coba()
        //{
        //    var user = HttpContext.User;
        //    var claims = user.Claims.ToList();
        //    return Ok(claims);
        //}
    }
}
