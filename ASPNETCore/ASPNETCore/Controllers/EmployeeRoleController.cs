using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    public class EmployeeRoleController : Controller
    {

        private IGenericRepository<EmployeeRole> repository = null;
        public EmployeeRoleController()
        {
            this.repository = new GeneralRepository<EmployeeRole>();
        }
        public EmployeeRoleController(IGenericRepository<EmployeeRole> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployeeRole(EmployeeRole obj)
        {
            if (ModelState.IsValid)
            {
                repository.Post(obj);
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
        //[HttpGet]
        //public ActionResult EditEmployeeRole(int id)
        //{
        //    Employee model = repository.GetById(id);
        //    return View(model);
        //}
        [HttpPost]
        public ActionResult EditEmployeeRole(EmployeeRole obj)
        {
            if (ModelState.IsValid)
            {
                repository.Put(obj);
                return RedirectToAction();
            }
            else
            {
                return View(obj);
            }
        }
        //[HttpGet]
        //public ActionResult DeleteEmployee(int EmployeeId)
        //{
        //    Employee model = repository.GetById(EmployeeId);
        //    return View(model);
        //}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction();
        }
    }
}
