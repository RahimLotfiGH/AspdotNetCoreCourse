using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication_01.Models;

namespace WebApplication_01.Controllers
{
    public class ActionsController : BaseController
    {
        //[Route("{controller}/show")]
        public IActionResult Index()
        {
            return View(new PersonVm { LastName = "Lotfi" });
        }


        [NonAction]
        public string GetName()
        {
            return "Rahim Lotfi";
        }


        public IEnumerable<PersonVm> GetPersonVms()
        {
            var personVms = new List<PersonVm>
            {
                new PersonVm{Id = 1,FirstName = "Rahim1",LastName = "Lotfi"},
                new PersonVm{Id = 2,FirstName = "Rahim2",LastName = "Lotfi"},
                new PersonVm{Id = 3,FirstName = "Rahim3",LastName = "Lotfi"},
            };

            return personVms;
        }


        public IActionResult _InsertUpdate(PersonVm personVm)
        {



            return RedirectToAction("Index");
        }


        public JsonResult GetPersonVms1()
        {
            var personVms = new List<PersonVm>
            {
                new PersonVm{Id = 1,FirstName = "Rahim1",LastName = "Lotfi"},
                new PersonVm{Id = 2,FirstName = "Rahim2",LastName = "Lotfi"},
                new PersonVm{Id = 3,FirstName = "Rahim3",LastName = "Lotfi"},
            };

            return Json(personVms);
        }

        public IActionResult GetMessage()
        {
            var message = "this  is a test";

            return Content(message);
        }


    }
}