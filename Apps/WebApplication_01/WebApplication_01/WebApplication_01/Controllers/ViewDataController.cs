using Microsoft.AspNetCore.Mvc;

namespace WebApplication_01.Controllers
{
    public class ViewDataController : Controller
    {
        public IActionResult Index()
        {

           // ViewData["UserName"] = "www.Heilton.com";

            return View();
        }
    }
}