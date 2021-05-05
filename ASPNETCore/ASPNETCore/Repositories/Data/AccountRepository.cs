using ASPNETCore.Context;
using ASPNETCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account, MyContext, int>
    {
        private readonly MyContext context;
        public AccountRepository(MyContext context) : base(context)
        {
            
        }

        //public new IEnumerable<Account> GetAll()
        //{
        //    var get = context.Set<Account>().Include("Role").ToList();
        //    return get;
        //}
    }
}
