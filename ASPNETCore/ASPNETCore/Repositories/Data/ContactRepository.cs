﻿using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace ASPNETCore.Repository.Data
{
    public class ContactRepository : GeneralRepository<Contact, MyContext, int>
    {
        private readonly MyContext context;
        public ContactRepository(MyContext context) : base(context)
=======
namespace ASPNETCore.Repositories.Data
{
    public class ContactRepository : GeneralRepository<Contact, MyContext, int>
    {
<<<<<<< Updated upstream
        private readonly MyContext myContext;

        public ContactRepository(MyContext myContext) : base(myContext)
>>>>>>> main
=======
        private readonly MyContext context;
        public ContactRepository(MyContext context) : base(context)
>>>>>>> Stashed changes
        {

        }
    }
}
