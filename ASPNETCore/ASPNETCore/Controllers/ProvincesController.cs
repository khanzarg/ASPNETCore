using ASPNETCore.Base;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : BaseController<Province, ProvinceRepository, int> 
    {
        private readonly ProvinceRepository provinceRepository;
        public ProvincesController(ProvinceRepository provinceRepository) : base(provinceRepository)
        {
            this.provinceRepository = provinceRepository;
        }
    }
}
