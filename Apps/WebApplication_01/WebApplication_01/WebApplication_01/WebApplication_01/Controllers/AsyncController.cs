using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_01.Controllers
{
    public class AsyncController : Controller
    {
        public IActionResult Index()
        {
            var result =  SumAsync().Result;

            return View();
        }

        public async Task<IActionResult> ShowAsync()
        {

            var result = await SumAsync();

            //await Task.Run(() =>
            //{

                //todo

            //});

            return View("ShowAsync");
        }

        private async Task<int> SumAsync()
        {
            var sum = 0;

            for (var i = 0; i < 10; i++)
            {
                sum += i;
                await Task.Delay(1000);
            }

            return sum;
        }


     

    }
}