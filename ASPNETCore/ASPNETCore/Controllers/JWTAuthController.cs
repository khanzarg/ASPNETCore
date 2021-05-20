using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Repositories.Interface;
using ASPNETCore.Services;
using ASPNETCore.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTAuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IGenericDapper _dapper;
        private readonly MyContext _context;
        private readonly LoginModelRepository _repository;
        public JWTAuthController(IConfiguration config, IGenericDapper dapper, MyContext context, LoginModelRepository repository)
        {
            _config = config;
            _dapper = dapper;
            _context = context;
            _repository = repository;
        }
        //private LoginModel AuthenticateUser(LoginModel login)
        //{
        //    LoginModel user = null;
        //    var isAuth = _context.LoginModels.SingleOrDefault(l => l.Username == login.Username);
        //    if (isAuth != null)
        //    {
        //        if (BCrypt.Net.BCrypt.Verify(login.Password, isAuth.Password))
        //        {
        //            user = new LoginModel { Username = isAuth.Username, EmailAddress = isAuth.EmailAddress };
        //        }
        //    }
        //    return user;
        //}

        //private int RegisterUser(Register register)
        //{
        //var isEmailExist = _context.Employees.SingleOrDefault(e => e.Email == register.Email);

        //if (isEmailExist == null)
        //{
        //    model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
        //    //_context.Set<LoginModel>().Add(model);
        //    var result = _repository.Post(model);
        //    return result;
        //}
        //return 0;
        //}
        

        private string GenerateJWT(string name, string email, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = Encoding.ASCII.GetBytes(_config["JwtAuth:secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)

                }),
                Expires = DateTime.Now.AddMinutes(1440),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature)
            };
            tokenDescriptor.Issuer = _config["JwtAuth:ValidIssuer"];
            tokenDescriptor.Audience = _config["JwtAuth:ValidAudience"];

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateResetPasswordToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = Encoding.ASCII.GetBytes(_config["JwtAuth:secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email)

                }),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature)
            };
            tokenDescriptor.Issuer = _config["JwtAuth:ValidIssuer"];
            tokenDescriptor.Audience = _config["JwtAuth:ValidAudience"];

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Email", login.Email, DbType.String);
            dynamic result = _dapper.Get<dynamic>(
                "[dbo].[SP_Login]", 
                dbparams, 
                CommandType.StoredProcedure
                );

            if (BCrypt.Net.BCrypt.Verify(login.Password, result.Password))
            {
                var token = GenerateJWT(result.Name, result.Email, result.Role);
                return Ok(new { token });
            }

            return Unauthorized();
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] Register register)
        {
            try
            {
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(register.Password);

                var dbparams = new DynamicParameters();
                dbparams.Add("Name", register.Name, DbType.String);
                dbparams.Add("Email", register.Email, DbType.String);
                dbparams.Add("Password", hashPassword, DbType.String);
                dbparams.Add("BirthDate", register.BirthDate, DbType.DateTime);
                dbparams.Add("Gender", register.Gender, DbType.String);
                dbparams.Add("Phone", register.Phone, DbType.String);
                dbparams.Add("Role", register.RoleId, DbType.Int32);

                var result = Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Register]"
                    , dbparams,
                    commandType: CommandType.StoredProcedure));

                return Ok(new { Status = "Success", Message = "User has been registered successfully" });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = "Failed", Message = "Email has already been registered"});
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            var currentUser = HttpContext.User;
            var claims = currentUser.Claims.ToList();
            
            return Ok("Name: " + claims[0].Value);
        }

        [HttpPut("change-password")]
        [Authorize]
        public ActionResult ChangePasswordUser(ChangePassword changePassword)
        {
            try
            {
                if (changePassword.NewPassword == changePassword.ConfirmPassword)
                {
                    var currentUser = HttpContext.User.Claims.ToList();

                    var email = currentUser.FirstOrDefault(c => c.Type.Contains("email")).Value;

                    LoginModel toUpdate = _context.LoginModels.FirstOrDefault(l => l.Employee.Email == email);

                    toUpdate.Password = BCrypt.Net.BCrypt.HashPassword(changePassword.NewPassword);

                    var result = _repository.Put(toUpdate);
                    if (result > 0)
                    {
                        return Ok(new { Status = "Success", Message = "Password has been updated" });
                    }
                }
                return BadRequest(new { Status = "Failed", Message = "Password does not match" });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public ActionResult ForgotPassword([FromBody] string email)
        {
            EmailManager emailManager = new EmailManager(_config, _context);

            var isValid = _context.LoginModels.SingleOrDefault(l => l.Employee.Email == email);
            if (isValid != null)
            {
                var token = GenerateResetPasswordToken(email);

                string subject = "Reset Password Token";
                string body = token;
                emailManager.SendEmail(_config.GetSection("MailSettings").GetSection("Mail").Value, subject, body, email);

                return Ok(new { Status = "Success", Message = "Token has been sent to your email" });
            }
            return NotFound("this email does not exist in database");
        }

        [HttpPut("reset-password")]
        [Authorize]
        public ActionResult ResetPassword(ChangePassword password)
        {
            try
            {
                if (password.NewPassword == password.ConfirmPassword)
                {
                    var currentUser = HttpContext.User.Claims.ToList();

                    var email = currentUser.FirstOrDefault(c => c.Type.Contains("email")).Value;
                    var isValid = _context.LoginModels.SingleOrDefault(l => l.Employee.Email == email);

                    isValid.Password = BCrypt.Net.BCrypt.HashPassword(password.NewPassword);

                    var result = _repository.Put(isValid);
                    if (result > 0)
                    {
                        return Ok(new { Status = "Success", Message = "Password has been reset" });
                    }
                }
                return BadRequest(new { Status = "Failed", Message = "Password does not match" });
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
