using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repository.Data
{
    public class ContactRepository : GeneralRepository<Contact, int>
    {
        //public ContactRepository(MyContext context) : base(context)
        //{
        //}
    }
}
