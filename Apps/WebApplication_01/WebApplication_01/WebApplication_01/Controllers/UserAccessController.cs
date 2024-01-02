using Microsoft.AspNetCore.Mvc;
using WebApplication_01.AppCode.Contracts;

namespace WebApplication_01.Controllers
{
    public class UserAccessController : Controller
    {
        private readonly IInMemoryUserAccessService _inMemoryUserAccessService;

        public UserAccessController(IInMemoryUserAccessService inMemoryUserAccessService)
        {
            _inMemoryUserAccessService = inMemoryUserAccessService;
        }

        public IActionResult Index()
        {
            _inMemoryUserAccessService.Add(1, new[] { 1, 2, 3, 4, 10 });
            _inMemoryUserAccessService.Add(2, new[] { 1, 5, 3, 4, 10 });
            _inMemoryUserAccessService.Add(3, new[] { 1, 100, 3, 88, 10 });

            return View();
        }

        public IActionResult Show()
        {
            var userAccess = _inMemoryUserAccessService.Get(2);

            return View("Index");
        }



    }
}