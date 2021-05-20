using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class DashboardController : Controller
    {
        //private readonly ILogger<DashboardController> _logger;

        //public DashboardController(ILogger<DashboardController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Indexdua()
        {
            return View();
        }
         public IActionResult Chart()
         {
            return View();
         }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
