using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMSServices.UserAccountServices.JWT;
using System.Diagnostics;
using PMS.Models;
using System;

namespace PMS.Controllers
{
    public class HomeController : Controller
    {
    public HomeController(ILogger<HomeController> logger,ITokenManager tokenManager)
        {
            
        }

        [HttpGet]
        [Route("/DashBoard")]
        public IActionResult Index()
        {

            return View();
        }

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
