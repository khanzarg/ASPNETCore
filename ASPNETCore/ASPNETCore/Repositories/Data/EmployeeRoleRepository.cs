using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.Models;
using ASPNETCore.Repositories;

namespace ASPNETCore.Repositories.Data
{
<<<<<<< Updated upstream
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, int>
    {

=======
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, MyContext, int>
    {
        private readonly MyContext context;
        public EmployeeRoleRepository(MyContext context) : base(context)
        {

        }
>>>>>>> Stashed changes
    }
}
