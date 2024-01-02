using Microsoft.AspNetCore.Mvc;
using WebApplication_01.Models.ViewComponentModels;

namespace WebApplication_01.ViewComponents
{
    public class ModalFormViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(ModalFormVc modalFormVc)
        {


            return View("Index", modalFormVc);
        }


    }
}
