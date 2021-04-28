using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class AddressRepository : GeneralRepository<Address, MyContext, int>
    {
        private readonly MyContext myContext;

        public AddressRepository(MyContext myContext) : base(myContext)
        {
         
        }
    }
}
