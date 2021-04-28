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

        }
    }
}
