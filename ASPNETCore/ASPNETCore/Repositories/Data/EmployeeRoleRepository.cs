using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, MyContext, int>
    {
        private readonly MyContext myContext;

        public EmployeeRoleRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
