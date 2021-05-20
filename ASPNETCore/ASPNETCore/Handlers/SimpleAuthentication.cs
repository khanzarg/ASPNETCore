using ASPNETCore.Context;
using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Handlers
{
    public class SimpleAuthentication
    {
        private readonly MyContext context;

        public SimpleAuthentication(MyContext context)
        {
            this.context = context;
        }
        public bool Check(string application, string token)
        {
            var parameter = context.Parameters.SingleOrDefault(x => x.Name == application);
            if (parameter.Value == token)
            {
                return true;
            }
            return false;
        }
    }
}
