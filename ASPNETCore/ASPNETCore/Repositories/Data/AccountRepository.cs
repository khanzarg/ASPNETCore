using ASPNETCore.Context;
using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account,MyContext,int>
    {
        private readonly MyContext myContext;
        public AccountRepository(MyContext myContext)  : base(myContext)
        {
            this.myContext = myContext;
        }

        public Account GetByEmail(string email)
        {
            var employee = myContext.Employees.SingleOrDefault(get => get.Email == email);
            var account = myContext.Accounts.SingleOrDefault(account => account.Id == employee.Id);
            return account;
        }
    }
}
