using ASPNETCore.Context;
using ASPNETCore.Interface;
using ASPNETCore.Models;
//using Google;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repository
{
    public class EmployeeRoleRepository : IEmployeeRoleRepository
    {
        private readonly MyContext context;
        public EmployeeRoleRepository(MyContext context)
        {
            this.context = context;
        }
        public void DeleteEmployeeRole(int Id)
        {
            EmployeeRole employee = context.employeeRoles.Find(Id);
            context.employeeRoles.Remove(employee);
        }

        public IEnumerable<EmployeeRole> GetEmployeeRole()
        {
            return context.employeeRoles.ToList();
        }

        public EmployeeRole GetEmployeeRoleByID(int Id)
        {
            return context.employeeRoles.Find(Id);
        }

        public void InsertEmployeeRole(EmployeeRole employeeRole)
        {
            context.employeeRoles.Add(employeeRole);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateEmployeeRole(EmployeeRole employeeRole)
        {
            var employeRole = context.employeeRoles.Attach(employeeRole);
            employeRole.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            
        }
    }
}
