using ASPNETCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Handlers
{
    public class SimpleAuthentication : MyContext
    {

        private readonly MyContext context;

        public SimpleAuthentication(MyContext context)
        {
            this.context = context;
        }
        public bool Check(string application, string token)
        {
            var result =  context.Parameters.SingleOrDefault(x => x.Name == application);
            if(result.Value == token)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
