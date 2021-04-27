using ASPNETCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repository.Data
{
    public class AddressRepository : GeneralRepository<AddressRepository>
    {
        public AddressRepository(MyContext context) : base(context)
        {
        }
    }
}
