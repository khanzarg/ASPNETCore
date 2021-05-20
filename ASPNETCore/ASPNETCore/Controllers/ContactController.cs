using ASPNETCore.Base;
using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    public class ContactController : BaseController<Contact, ContactRepository, int>
    {
        private readonly ContactRepository contactRepository;
        public ContactController(ContactRepository contactRepository) : base(contactRepository)
        {
            this.contactRepository = contactRepository;
        }
    }
}
