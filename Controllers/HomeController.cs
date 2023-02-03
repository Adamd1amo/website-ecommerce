using DoAn1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            string a = "";
        }

        public IActionResult Index()
        {
            string mess = "hello";
            return Privacy(mess);
        }

        
        public IActionResult Privacy(string mess)
        {
            ViewData["Mes"] = mess;
            return View();
        }
    }
}
