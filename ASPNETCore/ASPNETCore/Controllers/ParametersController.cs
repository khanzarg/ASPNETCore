using ASPNETCore.Base;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    public class ParametersController : BaseController<Parameter, ParameterRepository, int>
    {
        private readonly ParameterRepository parameterRepository;
        public ParametersController(ParameterRepository parameterRepository) : base(parameterRepository)
        {
            this.parameterRepository = parameterRepository;
        }

    }
}
