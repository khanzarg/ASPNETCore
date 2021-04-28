using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class ContactRepository : GeneralRepository<Contact, MyContext, int>
    {
        private readonly MyContext myContext;

        public ContactRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
