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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        private readonly MyContext context;
        public EmployeeRepository(MyContext context) : base(context)
        {
            
        } 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
        private readonly MyContext myContext;

        public EmployeeRepository(MyContext myContext) : base(myContext)
        {

        }
>>>>>>> main
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
}
