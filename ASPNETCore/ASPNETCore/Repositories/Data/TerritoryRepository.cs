using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class TerritoryRepository : GeneralRepository<Territory, MyContext, int>
    {
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
        private readonly MyContext context;
        public TerritoryRepository(MyContext context) : base(context)
        {

<<<<<<< Updated upstream
=======
        private readonly MyContext myContext;

        public TerritoryRepository(MyContext myContext) : base(myContext)
        {

>>>>>>> main
=======
>>>>>>> Stashed changes
        }
    }
}
