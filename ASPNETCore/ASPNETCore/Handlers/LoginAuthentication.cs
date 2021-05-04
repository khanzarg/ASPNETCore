using ASPNETCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Handlers
{
    public class LoginAuthentication
    {
        private MyContext context;
        public LoginAuthentication(MyContext context)
        {
            this.context = context;
        }

        public bool Authenticate(string email, string password)
        {
            var account = context.Accounts.SingleOrDefault(account => account.Email == email);
            if (account == null || !BCrypt.Net.BCrypt.Verify(password, account.Password))
            {
                return false;
            }
            return true;
        }
    }
}
