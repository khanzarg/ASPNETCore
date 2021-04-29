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
        public readonly MyContext context;
        public SimpleAuthentication(MyContext context) 
        {
            this.context = context;
        }
        public bool Check(string application, string token) 
        {
            var get = context.Parameters.SingleOrDefault(x => x.Name == application);
            if (get.Value == token)
            {
                return true;
            }
            return false;
        }
    }
}
