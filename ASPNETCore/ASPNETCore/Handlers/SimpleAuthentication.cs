using ASPNETCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Handlers
{
    public class SimpleAuthentication
    {
        private MyContext context;
        public SimpleAuthentication(MyContext context)
        {
            this.context = context;
        }

        public bool Check(string application, string token)
        {
            var get = context.Parameters.SingleOrDefault(x => x.Name == application);
            if (get.Value != token)
            {
                return false;
            }
            return true;
        }

        public bool CheckAdmin(string role)
        {
            var get = context.Roles.SingleOrDefault(x => x.Name == role);
            if(get.Name != "Admin")
            {
                return false;
            }
            return true;
        }
    }
}
