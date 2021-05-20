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
    public class MajorController : BaseController<Major, MajorRepository, int>
    {
        private readonly MajorRepository majorRepository;
        public MajorController(MajorRepository majorRepository) : base(majorRepository)
        {
            this.majorRepository = majorRepository;
        }
    }
}
