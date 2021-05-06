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
using System.Data;
using System.Data.SqlClient;
using Dapper;
using ASPNETCore.Repositories.Interface;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountRepository, int>
    {
        private readonly AccountRepository accountRepository;
        private readonly MyContext context;
        private IConfiguration _config;
        private readonly IGenericDapper _dapper;
        public AccountController(AccountRepository accountRepository, MyContext context, IConfiguration config, IGenericDapper dapper) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.context = context;
            _config = config;
            _dapper = dapper;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register(Register register)
        {

            var password = Hash.HashPassword(register.Password);
            var dbparams = new DynamicParameters();
            dbparams.Add("Name", register.Name, DbType.String);
            dbparams.Add("Email", register.Email, DbType.String);
            dbparams.Add("Password", password, DbType.String);
            dbparams.Add("BirthDate", register.BirthDate, DbType.String);
            dbparams.Add("Gender", register.Gender, DbType.String);
            dbparams.Add("Phone", register.Phone, DbType.String);
            dbparams.Add("Role", register.RoleId, DbType.String);

            var result = Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Register]", dbparams, commandType: CommandType.StoredProcedure));
            return Ok();
            //try
            //{
            //    var userExists = context.Employees.SingleOrDefault(e=>e.Email == register.Email);
            //    if (userExists != null) 
            //    {
            //        return BadRequest("User already exists.");
            //    }
            //    register.Password = Hash.HashPassword(register.Password);
            //    //Taro dapper disini
            //    //EF: Database.Execute query "SP_..." 

            //    //var result = accountRepository.Post(register) > 0 ? (ActionResult)Ok("Account has been created.") : BadRequest("User creation failed.");
            //    return Ok();
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e.InnerException);
            //}
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(Login login) 
        {
            var password = Hash.HashPassword(login.Password);

            var dbparams = new DynamicParameters();
            dbparams.Add("Email", login.Email, DbType.String);
            //dbparams.Add("Password", password, DbType.String);

            dynamic result = _dapper.Get<dynamic>("[dbo].[SP_Login]", dbparams, commandType: CommandType.StoredProcedure);

            //var user = context.Accounts.SingleOrDefault(a=>a.Employee.Email == login.Email);
            if (result != null && Hash.ValidatePassword(login.Password, result.Password)) 
            {
                
                var jwt = new JwtService(_config);
                var token = jwt.GenerateSecurityToken(result.Email, result.Name, result.Role);
                return Ok(token);
            }
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
            return BadRequest("Failed to login. Your email and password are not match");
        }

        [HttpPost]
        [Route("changepassword")]
        public ActionResult ChangePassword(string email, string oldPassword, string newPassword) 
        {
            try
            {
                var user = context.Accounts.SingleOrDefault(a => a.Employee.Email == email);
                var passwordCheck = Hash.ValidatePassword(oldPassword, user.Password);
                if (user != null && passwordCheck)
                {
                    var newPass = Hash.HashPassword(newPassword);
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
            //return Ok();
        }

        [HttpPost]
        [Route("forgotpassword")]
        public ActionResult ForgotPassword(string email)
        {
            try
            {
                //var email = Request.Headers["email"].ToString();
                var userExisting = context.Employees.SingleOrDefault(e => e.Email == email);
                var role = context.EmployeeRoles.SingleOrDefault(e => e.Role.Id == userExisting.Id);
                string resetCode = Guid.NewGuid().ToString();
                if (userExisting.Email == email)
                {
                    //create token
                    var jwt = new JwtService(_config);
                    var token = jwt.GenerateSecurityToken(userExisting.Email, userExisting.Name, role.Role.Name);

                    //Sending email
                    var sendEmail = new SendEmail(context);
                    sendEmail.SendForgotPassword(token, resetCode, email);
                    return Ok("Please check your email.");
                }
                return BadRequest("Email not found.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            //return Ok();
        }
        [Authorize]
        [HttpPost]
        [Route("resetpassword")]
        public ActionResult ResetPassword(string email, string newPassword, string confirmPassword)
        {
            try
            {
                var userExisting = context.Accounts.SingleOrDefault(e => e.Employee.Email == email);
                if (userExisting.Employee.Email == email)
                {
                    if (newPassword == confirmPassword)
                    {
                        userExisting.Password = Hash.HashPassword(newPassword);
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
            //return Ok();
        }
    }
}
