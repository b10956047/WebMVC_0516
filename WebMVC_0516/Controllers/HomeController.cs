using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC_0516.Models;
using WebMVC_0516.Sevice;

namespace WebMVC_0516.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MyCoutomService _myCustomService;

        public HomeController(ILogger<HomeController> logger, MyCoutomService myCustomService)
        {
            _logger = logger;
            _myCustomService = myCustomService;
        }

        public IActionResult Index()
        {
            ViewData["_myCustomService"] = _myCustomService.getMyName;
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
