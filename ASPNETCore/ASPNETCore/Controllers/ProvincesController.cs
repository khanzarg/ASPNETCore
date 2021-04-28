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
    public class ProvincesController : Controller
    {
        private IGeneralRepository<Province> repository = null;

        public ProvincesController()
        {
            repository = new GeneralRepository<Province>();
        }

        public ProvincesController(IGeneralRepository<Province> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var province = repository.GetAll();
            return View(province);
        }
        [HttpGet]
        public ActionResult AddProvince()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProvince(Province province)
        {
            if (ModelState.IsValid)
            {
                repository.Post(province);
                repository.Save();
                return RedirectToAction("Id", "Name");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditProvince(int Id)
        {
            Province province = repository.GetById(Id);
            return View(province);
        }
        [HttpPost]
        public ActionResult EditProvince(Province province)
        {
            if (ModelState.IsValid)
            {
                repository.Update(province);
                repository.Save();
                return RedirectToAction("Id", "Name");
            }
            else
            {
                return View(province);
            }
        }
        [HttpGet]
        public ActionResult DeleteProvince(int Id)
        {
            Province province = repository.GetById(Id);
            return View(province);
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            repository.Delete(Id);
            repository.Save();
            return RedirectToAction("Id", "Name");
        }
    }
}
