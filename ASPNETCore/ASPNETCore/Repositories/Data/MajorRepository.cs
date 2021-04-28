using ASPNETCore.Context;
using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class MajorRepository : GeneralRepository<Major, MyContext, int>
    {
        private readonly MyContext context;
        public MajorRepository(MyContext context) : base(context)
        {

        }
    }
}
