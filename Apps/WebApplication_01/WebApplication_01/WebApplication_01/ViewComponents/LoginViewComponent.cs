using Microsoft.AspNetCore.Mvc;
using WebApplication_01.Models.ViewComponentModels;

namespace WebApplication_01.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(LoginVc loginVc)
        {


            return View("Index",loginVc);
        }

    }
}
