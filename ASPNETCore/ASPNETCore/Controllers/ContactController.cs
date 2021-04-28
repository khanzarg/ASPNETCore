using ASPNETCore.Base;
using ASPNETCore.Context;
using ASPNETCore.Models;
<<<<<<< HEAD
using ASPNETCore.Repository;
using ASPNETCore.Repository.Data;
=======
using ASPNETCore.Repositories.Data;
>>>>>>> main
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : BaseController<Contact, ContactRepository, int>
    {
        private readonly ContactRepository contactRepository;
        public ContactController(ContactRepository contactRepository) : base(contactRepository)
        {
            this.contactRepository = contactRepository;
        }
    }
}
