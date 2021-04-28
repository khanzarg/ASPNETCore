using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class ProvinceRepository : GeneralRepository<Province, MyContext, int>
    {
        private readonly MyContext context;
        public ProvinceRepository(MyContext context) : base(context)
        {

        }
    }
}
