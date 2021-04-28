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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, int>
=======
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, MyContext, int>
>>>>>>> main
    {
        private readonly MyContext myContext;

        public EmployeeRoleRepository(MyContext myContext) : base(myContext)
        {

<<<<<<< HEAD
=======
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, MyContext, int>
    {
=======
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, MyContext, int>
    {
>>>>>>> Stashed changes
=======
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, MyContext, int>
    {
>>>>>>> Stashed changes
=======
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, MyContext, int>
    {
>>>>>>> Stashed changes
        private readonly MyContext context;
        public EmployeeRoleRepository(MyContext context) : base(context)
        {

        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
        }
>>>>>>> main
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
}
