﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCore.Services
{
    public class JwtServices
    {
        private readonly string _secret;
        private readonly string _expDate;

        public JwtServices(IConfiguration config)
        {
            _secret = config.GetSection("JwtAuth").GetSection("secret").Value;
            _expDate = config.GetSection("JwtAuth").GetSection("expirationInMinutes").Value;
        }

        public string GenerateSecurityToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            tokenDescriptor.Issuer = "localhost:44320";
            tokenDescriptor.Audience = "localhost:44320";
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
