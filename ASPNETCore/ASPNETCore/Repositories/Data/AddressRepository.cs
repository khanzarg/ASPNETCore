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
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        //public AddressRepository(MyContext context) : base(context)
        //{

        //}
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        private readonly MyContext context;
        public AddressRepository(MyContext context) : base(context)
        {
            
        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
        private readonly MyContext myContext;

        public AddressRepository(MyContext myContext) : base(myContext)
        {
         
        }
>>>>>>> main
=======
>>>>>>> Stashed changes
    }
}
