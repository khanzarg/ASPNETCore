using ASPNETCore.GenericRepository;
using ASPNETCore.Models;
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
    //public class AddressesController : ControllerBase{}
    public class AddressesController : Controller
    {
        private IGenericRepository<Address> repository = null;
        public AddressesController()
        {
            this.repository = new GenericRepository<Address>();
        }
        public AddressesController(IGenericRepository<Address> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAddress(Address model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return RedirectToAction("Index", "Address");
            }
            return View();
        }
        [HttpPut]
        public ActionResult EditAddress(int AddressId)
        {
            Address model = repository.GetById(AddressId);
            return View(model);
        }
        [HttpPut]
        public ActionResult EditEmployee(Address model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index", "Address");
            }
            else
            {
                return View(model);
            }
        }
        [HttpDelete]
        public ActionResult DeleteEmployee(int AddressId)
        {
            Address model = repository.GetById(AddressId);
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(int EmployeeID)
        {
            repository.Delete(EmployeeID);
            repository.Save();
            return RedirectToAction("Index", "Employee");
        }
    }
}
