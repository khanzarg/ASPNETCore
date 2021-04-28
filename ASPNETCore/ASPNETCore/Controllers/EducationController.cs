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
    public class EducationController : Controller
    {
        private IGeneralRepository<Education> repository = null;
        public EducationController()
        {
            this.repository = new GeneralRepository<Education>();
        }
        public EducationController(IGeneralRepository<Education> repository)
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
        public ActionResult AddEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                repository.Post(education);
                return RedirectToAction("");
            }
            return View();
        }
        //[HttpGet]
        //public ActionResult EditEducation(int Id)
        //{
        //    Education model = repository.GetById(EmployeeId);
        //    return View(model);
        //}
        [HttpPost]
        public ActionResult EditEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                repository.Put(education);
                return RedirectToAction("");
            }
            else
            {
                return View(education);
            }
        }
        //[HttpGet]
        //public ActionResult DeleteEducation(int Id)
        //{
        //    Employee model = repository.GetById(EmployeeId);
        //    return View(model);
        //}
        [HttpPost]
        public ActionResult DeleteEducation(int Id)
        {
            repository.Delete(Id);
            return RedirectToAction("");
        }
    }
}
