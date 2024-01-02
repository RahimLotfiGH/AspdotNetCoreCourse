using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebApplication_01.AppConsts;
using WebApplication_01.Models;

namespace WebApplication_01.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            return View(new LoginVm());
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(LoginVm loginVm)
        {

            //ToDo:Validation loginVm
            //ToDo: Find User

            await SignInAsync(loginVm.IsRememberMe);



            return View("Index", loginVm);
        }

        private async Task SignInAsync(bool isRememberMe)
        {
            var userClaim = GetClaimsIdentity();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(userClaim),
                                          new AuthenticationProperties
                                          {
                                              AllowRefresh = true,
                                              IsPersistent = true,
                                              ExpiresUtc = GetExpireDatetime(isRememberMe)
                                          });
        }

        private ClaimsIdentity GetClaimsIdentity()
        {
            return new ClaimsIdentity(new List<Claim>
            {
                new Claim(WebAuthorizeConsts.UserAccess,"1,2,3,4,5")

            }, CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private static DateTime GetExpireDatetime(bool isRememberMe)
        {
            return isRememberMe ?
                   DateTime.UtcNow.AddDays(30) :
                   DateTime.UtcNow.AddDays(1);
        }


        public async Task SignOutAsync()
        {
            HttpContext.Session.Clear();

            await HttpContext
                   .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

    }
}
