using Microsoft.AspNetCore.Mvc;

namespace WebApplication_01.Controllers
{
    public class TempDataController : Controller
    {
        public IActionResult Index()
        {
            TempData["userName"] = "www.Heilton.com";

            return View();

        }

        public IActionResult Show()
        {

            var value = TempData["userName"];

            TempData.Keep();

            return View();
        }

    }
}