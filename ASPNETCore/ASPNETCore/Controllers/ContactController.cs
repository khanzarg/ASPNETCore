using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repository;
using ASPNETCore.Repository.Data;
using ASPNETCore.Repository.Interface;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private MyContext context;
        private IGeneralRepository<Contact> repository = null;
        public ContactController()
        {
            this.repository = new GeneralRepository<Contact>();
        }
        public ContactController(GeneralRepository<Contact> repository)
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
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact model)
        {
            if (ModelState.IsValid)
            {
                repository.Post(model);
                context.SaveChanges();

            }
            return View();
        }
        [HttpGet]
        public ActionResult EditContact(int ContactId)
        {
            Contact model = repository.GetById(ContactId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditContact(Contact model)
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
        public ActionResult Contact(int Contact)
        {
            Contact model = repository.GetById(Contact);
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
