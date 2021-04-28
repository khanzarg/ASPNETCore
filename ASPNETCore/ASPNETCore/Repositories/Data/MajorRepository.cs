using ASPNETCore.Context;
using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    //dari Muljadi
    public class MajorRepository : GeneralRepository<Major, MyContext, int>
    {
<<<<<<< HEAD
        private readonly MyContext context;
        public MajorRepository(MyContext context) : base(context)
        {

=======
        private readonly MyContext myContext;

        public MajorRepository(MyContext myContext) : base(myContext)
        {

>>>>>>> main
        }
    }
}
