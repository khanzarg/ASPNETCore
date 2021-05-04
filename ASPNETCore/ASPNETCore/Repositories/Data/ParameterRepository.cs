using ASPNETCore.Context;
using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class ParameterRepository : GeneralRepository<Parameter, MyContext, int>
    {
        private readonly MyContext myContext;

        public ParameterRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public bool Authenticate(Parameter model)
        {
            // get account from database
            var account = myContext.Parameters.SingleOrDefault(x => x.Name == model.Name);

            // check account found and verify password
            if (account == null || !BCrypt.Net.BCrypt.Verify(model.Value, account.Value))
            {
                // authentication failed
                return false;
            }
            else
            {
                // authentication successful
                return true;
            }
        }


    }
}

