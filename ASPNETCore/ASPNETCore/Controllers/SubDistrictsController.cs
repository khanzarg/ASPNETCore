﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.Base;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using ASPNETCore.Repositories.Data;

namespace ASPNETCore.Controllers
{
    public class SubDistrictsController : BaseController<SubDistrict, SubDistrictRepository, int>
    {
        private readonly SubDistrictRepository subDistrictRepository;
        public SubDistrictsController(SubDistrictRepository subDistrictRepository) : base(subDistrictRepository)
        {
            this.subDistrictRepository = subDistrictRepository;
        }
    }

}


