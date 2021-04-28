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
<<<<<<< Updated upstream
<<<<<<< HEAD
        private readonly MyContext context;
        public DistrictRepository(MyContext context) : base(context)
=======
        private readonly MyContext myContext;

        public DistrictRepository(MyContext myContext) : base(myContext)
>>>>>>> main
=======
        private readonly MyContext context;
        public DistrictRepository(MyContext context) : base(context)
>>>>>>> Stashed changes
        {

        }
    }
}


   
