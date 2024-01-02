using Microsoft.AspNetCore.Mvc;

namespace WebApplication_01.Controllers
{
    public class FormsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}