using Microsoft.AspNetCore.Mvc;
using WebApplication_01.AppCode;
using WebApplication_01.Models;

namespace WebApplication_01.Controllers
{
    public class GenericController : Controller
    {
        public IActionResult Index()
        {

            var myGenericClass = new MyGenericClass<int, string>();

            myGenericClass.Id1 = 10;



            var myGenericClass1 = new MyGenericClass<string, long>();

            myGenericClass1.Id1 = "12369";

            myGenericClass1.ShowValue(120);

            return View();
        }


        public IActionResult ShowResult()
        {
            var genericRepo = new GenericRepo<Person, string>();

            genericRepo.Add(new Person
            {
                Id = 10,
                FirstName = "Rahim",
                LastName = "Lotfi"
            });

            return View("Index");
        }

    }
}