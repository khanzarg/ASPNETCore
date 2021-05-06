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
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using ASPNETCore.Repositories.Interface;

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
        private readonly IGenericDapper _dapper;

        public AccountController(AccountRepository accountRepository, MyContext context, IConfiguration _config, SendEmail sendEmail, IGenericDapper dapperr) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.context = context;
            this._config = _config;
            this.sendEmail = sendEmail;
            _dapper = dapperr;
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
            string passwordHash = BC.HashPassword(register.Password);
            var dbparams = new DynamicParameters();
            dbparams.Add("Name", register.Name, DbType.String);
            dbparams.Add("Email", register.Email, DbType.String);
            dbparams.Add("Password", passwordHash, DbType.String);
            dbparams.Add("BirthDate", register.BirthDate, DbType.DateTime);
            dbparams.Add("Gender", register.Gender, DbType.String);
            dbparams.Add("Phone", register.Phone, DbType.String);
            dbparams.Add("Role", register.RoleId, DbType.Int32);
            var result = Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Register]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return Ok("Sucesfully Registered");
        }
        
        [HttpPost("Login/")]
        public ActionResult Login(Login login)
        {
            try
            {
               
                var dbparams = new DynamicParameters();
                dbparams.Add("Email", login.Email, DbType.String);
                dynamic result = _dapper.Get<dynamic>("[dbo].[SP_Login]"
                , dbparams,
                commandType: CommandType.StoredProcedure);

                if (BC.Verify(login.Password, result.Password))
                {
                    var jwt = new JwtService(_config);
                    var token = jwt.GenerateSecurityLoginToken(result.Name, result.Email, result.Role);
                    return Ok(new { token });
                }
                
                return Unauthorized("Failed To Make Token, Email / Password Wrong");                
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);

            }

        }

        [HttpPost("Forget-Password")]
        public ActionResult ForgetPassword()
        {

            string headerEmail = Request.Headers["Email"].ToString();
            var foundAccount = context.Accounts.Where(account => account.Employee.Email == headerEmail).FirstOrDefault();
            if (foundAccount == null)
            {
                return NotFound("Email Not Found");
            }
            else
            {
                var foundEmployee = context.Employees.Where(employee => employee.Id == foundAccount.Id).FirstOrDefault();
                var jwt = new JwtService(_config);
                string token = jwt.GenerateSecurityToken(headerEmail);
                string url = "https://localhost:44320/api/Account/Reset-Password?Token=";

                var sendEmail = new SendEmail(context);
                sendEmail.SendForgetPassword(url, token, foundEmployee);
                return Ok("Please Check Email");
                
            }

        }

        [HttpPost("Reset-Password")]
        public ActionResult ResetPassword()
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var readToken = tokenHandler.ReadJwtToken(Request.Query["Token"]);

            var newPassword = Request.Headers["NewPassword"].ToString();
            var confirmPassword = Request.Headers["ConfirmPassword"].ToString();

            if (newPassword == confirmPassword)
            {
                var getEmail = readToken.Claims.First(getEmail => getEmail.Type == "email").Value;
                var foundAccount = context.Accounts.Where(account => account.Employee.Email == getEmail).FirstOrDefault();

                if (foundAccount == null)
                {
                    return NotFound("Wrong Email");
                }
                else
                {
                    string passwordHash = BC.HashPassword(newPassword);
                    foundAccount.Password = passwordHash;
                    var result = accountRepository.Put(foundAccount) > 0 ? (ActionResult)Ok("Data has been successfully updated.") : BadRequest("Data can't be updated.");
                    return result;
                }
            }
            else
            {
                return BadRequest("New Password & Confirm Password Must Same");
            }

        }

        [HttpPost("Change-Password")]
        public ActionResult ChangePassword()
        {

            string email = Request.Headers["Email"].ToString();
            string currentPassword = Request.Headers["CurrentPassword"].ToString();
            string newPassword = Request.Headers["NewPassword"].ToString();
            string confirmPassword = Request.Headers["ConfirmPassword"].ToString();
            var foundAccount = context.Accounts.Where(account => account.Employee.Email == email).FirstOrDefault();

            if (foundAccount == null || !BC.Verify(currentPassword, foundAccount.Password))
            {
                return NotFound("Wrong Email / Current Password");
            }
            else if (newPassword != confirmPassword)
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
