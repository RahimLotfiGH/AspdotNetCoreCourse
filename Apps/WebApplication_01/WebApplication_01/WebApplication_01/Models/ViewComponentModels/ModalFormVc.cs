using System;

namespace WebApplication_01.Models.ViewComponentModels
{
    public class ModalFormVc
    {

        public string Title { get; set; }

        public string ActionName { get; set; }

        public Func<object, object> Content { get; set; }

    }
}
