using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class TerritoryRepository : GeneralRepository<Territory, MyContext, int>
    {
        private readonly MyContext context;
        public TerritoryRepository(MyContext context) : base(context)
        {

        }
    }
}
