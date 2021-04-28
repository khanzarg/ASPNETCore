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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
        private readonly MyContext context;
        public UniversityRepository(MyContext context) : base(context)
=======
        private readonly MyContext myContext;

        public UniversityRepository(MyContext myContext) : base(myContext)
>>>>>>> main
=======
        private readonly MyContext context;
        public UniversityRepository(MyContext context) : base(context)
>>>>>>> Stashed changes
=======
        private readonly MyContext context;
        public UniversityRepository(MyContext context) : base(context)
>>>>>>> Stashed changes
        {

        }
    }
}
