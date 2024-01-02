using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication_01.AppConsts;
using WebApplication_01.Models;

namespace WebApplication_01.Controllers
{
    public class BaseController : Controller
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //todo:
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

            var model = ViewData.Model;
            if (model is null)
            {
                model = new BaseVm
                {
                    PageTitle = "به وب سایت هیلتن خوش آمدید"
                };
            }
            else
            {
                var vm = (BaseVm)model;
                vm.PageTitle = "به وب سایت هیلتن خوش آمدید";
            }

            ViewData.Model = model;

            base.OnActionExecuted(context);
        }

        protected void SetSession(string name, string value)
        {
            HttpContext.Session.SetString(name, value);
        }

        protected string GetSession(string name)
        {
            return HttpContext.Session.GetString(name);
        }

        protected void SetCookie(string name, string value)
        {
            //Response.Cookies.Append(name,value);
        }

        protected string GetCookie(string name)
        {
            return Request.Cookies[name];
        }

        protected void ShowMessage(string message)
        {
            TempData[TempDataNameConsts.Message] = message;
        }

    }
}