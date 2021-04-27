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
    public class DistrictController : Controller
    {
        private IGenericRepository<District> repository = null;

        public DistrictController()
        {
            this.repository = new GeneralRepository<District>();
        }

        public DistrictController(IGenericRepository<District> repository)
        {
            this.repository = repository;
        }


        //GetAll District
        [Route("api/{controller}/id")]
        [HttpGet]
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View (model);
        }

        [Route("api/{controller}/id")]
        [HttpGet]
        public ActionResult GetById(int id)
        {
            var get = repository.GetById(id);
            if (get == null)
            {
                return NotFound("Data tidak ditemukan");
            }
            else
            {
                return Ok(get);
            }
        }


        //Insert District
        [HttpPost]
        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(District model)
        {
            if (ModelState.IsValid)
            {
                repository.Post(model);
                return RedirectToAction("Index", "District");
            }
            return View();
        }

         //Edit District
        [Route("api/{controller}/id")] 
        [HttpGet]
        public ActionResult PutDistrict(int id)
        {
            District model = repository.GetById(id);
            return View(model);
        }

        
        [HttpPost]
        public ActionResult PutDistrict(District model)
        {
            if (ModelState.IsValid)
            {
                repository.Put(model);
                return RedirectToAction("Index", "District");
            }
            else
            {
                return View(model);
            }
        }

        //Hapus District
        [Route("api/{controller}/id")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            District model = repository.GetById(id);
            return View(model);
        }

        [Route("api/{controller}/id")]
        [HttpDelete]
        public ActionResult Delete(District model)
        {
           
            repository.Delete(model);
            return RedirectToAction("Index", "SubDistrict");
        }
        
    }
}


