using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionApp.AppCode.Contract;
using DependencyInjectionApp.AppCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DependencyInjectionApp.Models;

namespace DependencyInjectionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISalaryService _salaryService;
        public HomeController(ILogger<HomeController> logger, 
                       ISalaryService salaryService)
        {
            _logger = logger;
            _salaryService = salaryService;
        }

        public IActionResult Index()
        {

            var data = _salaryService.Calc();
         

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
