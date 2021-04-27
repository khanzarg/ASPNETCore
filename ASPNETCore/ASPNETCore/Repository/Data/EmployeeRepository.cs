using ASPNETCore.Models;
using ASPNETCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee>
    {
        private IGenericRepository<Employee> repository = null;
        public EmployeeRepository()
        {
            repository = new GeneralRepository<Employee>();
        }
        //public EmployeeRepository(IGenericRepository<Employee> repository)
        //{
        //    this.repository = repository;
        //}

        public IEnumerable<Employee> GetEmployees()
        {
            var get = repository.GetAll();
            return get;
        }
        public Employee GetEmployeeById(int id)
        {
            var getId = repository.GetById(id);
            return getId;
        }
        public void InsertEmployee(Employee employee)
        {
            repository.Insert(employee);
            repository.Save();
        }
        public void UpdateEmployee(Employee employee)
        {
            repository.Update(employee);
            repository.Save();
        }
        public void DeleteEmployee(int id)
        {
            repository.Delete(id);
            repository.Save();
        }
    }
}
