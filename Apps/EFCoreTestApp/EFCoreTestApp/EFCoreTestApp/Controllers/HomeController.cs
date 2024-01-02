using System.Diagnostics;
using System.Linq;
using EFCoreTestApp.AppContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFCoreTestApp.Models;
using EFCoreTestApp.Models.Entities;
using EFCoreTestApp.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStudentService _studentService;

        public HomeController(ILogger<HomeController> logger
                              , IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        public IActionResult Index()
        {

            var students = _studentService
                                    .GetAll()
                                    .ToList();
                                   
            //_studentService.Delete(1);

            _studentService.Update(new Student
            {
                Id = 2,
                FirstName = "hasan",
                LastName = "Lotfi"
            });


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
