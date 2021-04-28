using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class DistrictRepository : GeneralRepository<District, MyContext, int>
    {
        private readonly MyContext myContext;

        public DistrictRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}


   
