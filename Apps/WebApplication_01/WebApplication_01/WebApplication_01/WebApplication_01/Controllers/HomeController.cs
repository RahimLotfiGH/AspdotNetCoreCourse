using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication_01.AppConsts;
using WebApplication_01.Models;

namespace WebApplication_01.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var userName = GetCookie(CookiesNamesConsts.UserName);

            //SetSession(SessionNamesConsts.UserName, "Rahim Lotfi");

            //var userName = GetSession(SessionNamesConsts.UserName);

            return View();
        }

        public IActionResult Privacy()
        {
            SetCookie(CookiesNamesConsts.UserName, "RahimLotfi");


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
