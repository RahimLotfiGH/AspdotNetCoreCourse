using Microsoft.AspNetCore.Mvc;
using WebApplication_01.AppCode;
using WebApplication_01.AppConsts;

namespace WebApplication_01.Controllers
{

    public class LoginTestController : Controller
    {

        [WebAuthorize(ActionAccessConsts.LoginTest)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
