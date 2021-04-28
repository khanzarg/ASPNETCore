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
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
        private readonly MyContext context;
        public EducationRepository(MyContext context) : base(context)
        {

<<<<<<< Updated upstream
=======
        private readonly MyContext myContext;

        public EducationRepository(MyContext myContext) : base(myContext)
        {

>>>>>>> main
=======
>>>>>>> Stashed changes
        }
    }
}
