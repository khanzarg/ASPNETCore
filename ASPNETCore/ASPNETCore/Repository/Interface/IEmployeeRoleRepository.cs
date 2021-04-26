using ASPNETCore.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Interface
{
    interface IEmployeeRoleRepository
    {
        IEnumerable<EmployeeRole> GetEmployeeRole();
        EmployeeRole GetEmployeeRoleByID(int Id);
        void InsertEmployeeRole(EmployeeRole employeeRole);
        void DeleteEmployeeRole(int Id);
        void UpdateEmployeeRole(EmployeeRole employeeRole);
        void Save();
    }
}
