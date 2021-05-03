﻿using ASPNETCore.Context;
using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account, MyContext, int>
    {
        private readonly MyContext myContext;

        public AccountRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}