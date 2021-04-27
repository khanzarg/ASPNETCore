using ASPNETCore.Base;
using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Interface;
using ASPNETCore.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : BaseController<Address, AddressRepository, int>
    {
        private readonly AddressRepository addressRepository;
        public AddressesController(AddressRepository addressRepository) : base(addressRepository)
        {
            this.addressRepository = addressRepository;
        }

    }
}
