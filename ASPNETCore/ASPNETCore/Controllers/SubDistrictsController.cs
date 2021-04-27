using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore.Controllers
{
    [Route("api/SubDistricts")]
    [ApiController]
    public class SubDistrictsController : Controller
    {
        private IGenericRepository<SubDistrict> repoSubDistrict;
        //passing an instance of IGenericRepository into SubDistrictsController
        public SubDistrictsController(IGenericRepository<SubDistrict> repoSubDistrict)
            {
            this.repoSubDistrict = repoSubDistrict;
            }

        //Get All SubDistrict
        [Route("~/api/Index")]
        [HttpGet]
        public ActionResult Index()
        {
            var model = repoSubDistrict.GetAll();
            return View(model);
        }


        [Route("~/api/Get/{id}")]
        [HttpGet]
        public ActionResult Get(int id)
        {
            SubDistrict model = repoSubDistrict.GetById(id);
            return View(model);
        }

        //Insert Subdistrict
        [HttpPost]
        public ActionResult Post()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Post(SubDistrict subDistrict)
        {
            if (ModelState.IsValid)
            {
                repoSubDistrict.Post(subDistrict);
                return RedirectToAction("Index", "SubDistrict");
            }
            return View();
        }

        //Edit SubDistrict
        [Route("~/api/Put/{id}")]
        [HttpGet]
        public ActionResult Put(int id)
        {
            SubDistrict model = repoSubDistrict.GetById(id);
            return View(model);
        }


        [HttpPost]
        public ActionResult Put(SubDistrict subDistrict)
        {
            if (ModelState.IsValid)
            {
                repoSubDistrict.Put(subDistrict);
                return RedirectToAction("Index", "SubDistrict");
            }
            else
            {
                return View(subDistrict);
            }
        }


        //Delete Employee
        [Route("~/api/Delete/{id}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            SubDistrict model = repoSubDistrict.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(SubDistrict  subDistrict)
        {
            repoSubDistrict.Delete(subDistrict);
            return RedirectToAction("Index", "SubDistrict");
        }
    }
 
}


