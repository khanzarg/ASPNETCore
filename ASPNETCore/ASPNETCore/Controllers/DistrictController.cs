using ASPNETCore.Base;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    public class DistrictController : BaseController<District, DistrictRepository, int>
    {
        private readonly DistrictRepository districtRepository;
        public DistrictController(DistrictRepository districtRepository) : base(districtRepository)
        {
            this.districtRepository = districtRepository;
        }
    }
}


