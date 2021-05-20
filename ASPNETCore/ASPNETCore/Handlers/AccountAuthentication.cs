using ASPNETCore.Context;
using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Handlers
{
    public class AccountAuthentication
    {
        private MyContext myContext;
        public AccountAuthentication(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public bool VerifyPassword(string email, string password)
        {
            var account = GetAccount(email);    
            if (BCrypt.Net.BCrypt.Verify(password, account.Password))
            {
                return true;
            }
            return false;
        }

        public Account GetAccount(string email)
        {
            var employee = myContext.Employees.SingleOrDefault(employee => employee.Email == email);
            var account = myContext.Accounts.SingleOrDefault(account => account.Id == employee.Id);
            return account;
        }

        //public Account GetAccount(int id)
        //{
        //    var employee = myContext.Employees.SingleOrDefault(employee => employee.Id == id);
        //    var account = myContext.Accounts.SingleOrDefault(account => account.Id == employee.Id);
        //    return account;
        //}

        public bool CheckEmail(string email)
        {
            var employee = myContext.Employees.SingleOrDefault(employee => employee.Email == email);
            if (employee == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Encrypt(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }
    }
}
