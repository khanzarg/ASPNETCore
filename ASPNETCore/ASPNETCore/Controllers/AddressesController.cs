using ASPNETCore.Base;
using ASPNETCore.Context;
using ASPNETCore.Handlers;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Repositories.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ASPNETCore.Controllers
{
    [EnableCors("Accounts")]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : BaseController<Address, AddressRepository, int>
    {
  
        private readonly AddressRepository addressRepository;
        private readonly SimpleAuthentication simpleAuthentication;

        public AddressesController(AddressRepository addressRepository, SimpleAuthentication simpleAuthentication) : base(addressRepository)
        {
            this.addressRepository = addressRepository;
            this.simpleAuthentication = simpleAuthentication;
        }

        [HttpGet("CheckAddresses/")]
        public string CheckAddresses()
        {
            var headerApp = Request.Headers["Application"].ToString();
            var headerToken = Request.Headers["Token"].ToString();
            
            var result = simpleAuthentication.Check(headerApp, headerToken);
            
            if (result)
            {
                return "OK";
            }
            return "Not OK";
        }
    }
}
