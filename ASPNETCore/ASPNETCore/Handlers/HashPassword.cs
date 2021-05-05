using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace ASPNETCore.Handlers
{
    public class HashPassword
    {
        public static string Encrypt(string password)
        {
            return BC.HashPassword(password);

        }
        public static bool Verify(string password, string hashPassword)
        {
            return BC.Verify(password, hashPassword);
        }
    }
}
