using ASPNETCore.Context;
using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Role, MyContext, int>
    {
        private readonly MyContext myContext;

        public RoleRepository(MyContext myContext) : base(myContext)
        {
            //master khanza
        }
    }
}
