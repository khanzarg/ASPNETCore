using ASPNETCore.Context;
using ASPNETCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class LoginModelRepository : GeneralRepository<LoginModel, MyContext, int>
    {
        private readonly MyContext context;
        public LoginModelRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
