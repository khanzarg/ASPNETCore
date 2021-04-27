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
    public class RoleController : Controller
    {
        private IGenericRepository<Role> repository = null;
        public RoleController()
        {
            this.repository = new GeneralRepository<Role>();
        }
        public RoleController(IGenericRepository<Role> repository)
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
        public ActionResult AddRole(Role obj)
        {
            if (ModelState.IsValid)
            {
                repository.Post(obj);
                return RedirectToAction("");
            }
            return View();
        }
        //[HttpGet]
        //public ActionResult EditRole(int Id)
        //{
        //    Role model = repository.GetById(EmployeeId);
        //    return View(model);
        //}
        [HttpPost]
        public ActionResult EditRole(Role obj)
        {
            if (ModelState.IsValid)
            {
                repository.Put(obj);
                return RedirectToAction("");
            }
            else
            {
                return View(obj);
            }
        }
        //[HttpGet]
        //public ActionResult DeleteRole(int Id)
        //{
        //    Employee model = repository.GetById(EmployeeId);
        //    return View(model);
        //}
        [HttpPost]
        public ActionResult DeleteRole(int Id)
        {
            repository.Delete(Id);
            return RedirectToAction("");
        }
    }
}
