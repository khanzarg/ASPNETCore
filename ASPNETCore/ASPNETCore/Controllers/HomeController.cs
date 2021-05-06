using ASPNETCore.Services;
using ASPNETCore.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.ViewModels;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IDapperr _dapper;
        public HomeController(IDapperr dapper)
        {
            _dapper = dapper;
        }

        [HttpPost(nameof(Create))]
        public async Task<int> Create(Register data)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(data.Name, data.Email, DbType.Int32);
            var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Register]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
