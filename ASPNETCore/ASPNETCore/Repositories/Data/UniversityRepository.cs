using ASPNETCore.Context;
using ASPNETCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class UniversityRepository : GeneralRepository<University, MyContext, int>
    {
        private readonly MyContext context;
        public UniversityRepository(MyContext context) : base(context)
        {

        }
    }
}
