using Microsoft.AspNetCore.Mvc;
using WebApplication_01.Models;

namespace WebApplication_01.Controllers
{
    public class ViewBagController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.UserName = "Heilton";
            ViewBag.personVm = CreatePersonVm();

            return RedirectToAction("Show");
        }

        private static PersonVm CreatePersonVm()
        {
            return new PersonVm
            {
                Id = 10,
                FirstName = "rahim",
                LastName = "lotfi"
            };
        }


        public IActionResult Show()
        {

            return View();
        }


    }
}