using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : Controller
    {
        private MyContext context;
        private GeneralRepository<Address> repository = null;
        public AddressesController()
        {
            this.repository = new GeneralRepository<Address>();
        }
        public AddressesController(GeneralRepository<Address> repository)
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
        public ActionResult AddAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAddress(Address model)
        {
            if (ModelState.IsValid)
            {
                repository.Post(model);
                context.SaveChanges();

            }
            return View();
        }
        [HttpGet]
        public ActionResult EditAddress(int AddressId)
        {
            Address model = repository.GetById(AddressId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditAddress(Address model)
        {
            if (ModelState.IsValid)
            {
                repository.Put(model);
                context.SaveChanges();
                return View(model);
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Address(int Address)
        {
            Address model = repository.GetById(Address);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int Address)
        {
            repository.Delete(Address);
            var model = context.SaveChanges();
            return View(model);
        }
    }
}
