using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, MyContext, int>
    {
        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        //public string EmailCheck(string email, string password)
        //{
          
        //    if (myContext.Employees.Any(emp=> emp.Email == email))
        //    {
        //        var model = myContext.Employees.SingleOrDefault(emp => emp.Email == email);
        //        var result = BCrypt.Net.BCrypt.Verify(password, model.Password) == true ? "Login Successfull" : "Password is not correct";
        //        return result;
        //    }
        //    else
        //    {
        //        return "Email is not registered";
        //    }
        //}
    }
}
