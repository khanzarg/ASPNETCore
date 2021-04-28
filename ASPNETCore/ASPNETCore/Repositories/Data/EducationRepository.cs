using ASPNETCore.Context;
using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class EducationRepository : GeneralRepository<Education, MyContext, int>
    {
        private readonly MyContext context;
        public EducationRepository(MyContext context) : base(context)
        {

        }
    }
}
