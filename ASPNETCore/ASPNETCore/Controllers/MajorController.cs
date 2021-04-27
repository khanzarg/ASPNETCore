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
    //Punya Muljadi
    //MajorRepository
    //MajorRepository
    public class MajorRepository : GeneralRepository<Major>
    {
        //readonly MyContext _context;
        //public MajorRepository(MyContext context) : base(context)
        //{
        //    _context = context;
        //}
    }
    //MajorController
    public class MajorController : Controller
    {
        private IGeneralRepository<Major> repository = null;
        public MajorController()
        {
            this.repository = new GeneralRepository<Major>();
        }
        public MajorController(IGeneralRepository<Major> repository)
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
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                repository.Post(major);
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
        public ActionResult EditMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                repository.Put(major);
                return RedirectToAction("");
            }
            else
            {
                return View(major);
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
