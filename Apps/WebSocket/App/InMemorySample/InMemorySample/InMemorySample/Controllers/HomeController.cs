using System.Diagnostics;
using InMemorySample.AppCode;
using Microsoft.AspNetCore.Mvc;
using InMemorySample.Models;

namespace InMemorySample.Controllers
{
    public class HomeController : Controller
    {

        private readonly IInMemoryService _inMemoryService;

        public HomeController(IInMemoryService inMemoryService)
        {
            _inMemoryService = inMemoryService;
        }

        public IActionResult Index()
        {

            //Go To address https://localhost:44328/home/add/11


            return View();
        }

        public IActionResult Add(string id)
        {
            _inMemoryService.Add(id, "www.Heilton.com"+id);



            return View("Index");
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
