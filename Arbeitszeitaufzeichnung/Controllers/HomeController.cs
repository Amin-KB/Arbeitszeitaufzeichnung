using Arbeitszeitaufzeichnung.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var uNi = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var uN = User.Claims.First(c => c.Type == ClaimTypes.Name).Value;
                var uE = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
                var uR = User.Claims.First(c => c.Type == ClaimTypes.Role).Value; 
            }

            return View();
        }

        //[Authorize] // Allgemeiner Login erforderlich für diese Methode
        [Authorize(Roles ="1")]// Admin
        public IActionResult Privacy()
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
