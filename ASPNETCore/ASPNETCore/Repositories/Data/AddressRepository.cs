using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repository.Data
{
    public class AddressRepository : GeneralRepository<Address, MyContext, int>
    {
<<<<<<< Updated upstream
        //public AddressRepository(MyContext context) : base(context)
        //{

        //}
=======
        private readonly MyContext context;
        public AddressRepository(MyContext context) : base(context)
        {
            
        }
>>>>>>> Stashed changes
    }
}
