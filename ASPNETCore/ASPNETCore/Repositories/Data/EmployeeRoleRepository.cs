using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.Models;
using ASPNETCore.Repositories;

namespace ASPNETCore.Repositories.Data
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, int>
    {

=======
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, MyContext, int>
    {
=======
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, MyContext, int>
    {
>>>>>>> Stashed changes
        private readonly MyContext context;
        public EmployeeRoleRepository(MyContext context) : base(context)
        {

        }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
}
