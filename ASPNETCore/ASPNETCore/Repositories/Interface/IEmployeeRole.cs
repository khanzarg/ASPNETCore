using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Interface
{
    interface IEmployeeRole: IGenericRepository<EmployeeRole>
    {
        IEnumerable<EmployeeRole> GetEmployeesByGender(string Gender);
        IEnumerable<EmployeeRole> GetEmployeesByDepartment(string Dept);
    }
}
