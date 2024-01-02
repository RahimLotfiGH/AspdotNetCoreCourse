using Microsoft.AspNetCore.Mvc;
using WebApplication_01.Models;

namespace WebApplication_01.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {

            return View(new PersonVm());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowPerson(PersonVm personVm)
        {

            //todo

            return View(personVm);
        }

    }
}