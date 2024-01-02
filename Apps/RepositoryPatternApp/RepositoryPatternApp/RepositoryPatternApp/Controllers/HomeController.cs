using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryPatternApp.Models;
using RepositoryPatternApp.RepoPattern;

namespace RepositoryPatternApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Person> _personRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public HomeController(
            ILogger<HomeController> logger, 
            IGenericRepository<Person> personRepository, 
            IGenericRepository<Teacher> teacherRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
            _teacherRepository = teacherRepository;
        }

        public IActionResult Index()
        {
            var person = new Person
            {
                Id = 1,
                FirstName = "Ali",
                LastName = "Lotfi"

            };
            
            _personRepository.Add(person);

            var data = _personRepository.GetAll();


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
