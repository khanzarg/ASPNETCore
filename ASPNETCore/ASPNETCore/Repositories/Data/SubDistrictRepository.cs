﻿using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class SubDistrictRepository : GeneralRepository<SubDistrict, MyContext, int>
    {
<<<<<<< Updated upstream
<<<<<<< HEAD
        private readonly MyContext context;
        public SubDistrictRepository(MyContext context) : base(context)
=======
        private readonly MyContext myContext;

        public SubDistrictRepository(MyContext myContext) : base(myContext)
>>>>>>> main
=======
        private readonly MyContext context;
        public SubDistrictRepository(MyContext context) : base(context)
>>>>>>> Stashed changes
        {

        }
    }


}
