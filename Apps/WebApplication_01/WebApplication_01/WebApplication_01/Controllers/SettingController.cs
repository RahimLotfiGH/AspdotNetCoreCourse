using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication_01.Tools.JsonSetting;

namespace WebApplication_01.Controllers
{
    public class SettingController : Controller
    {
        public IActionResult Index()
        {

            var value = AppSetting.AppName;
            var siteName = AppSetting.Site;

            //var config = new ConfigurationBuilder();

            //var appSettingFilePath = Path.Combine(Directory.GetCurrentDirectory(),
            //                                "appsettings.json");

            //config.AddJsonFile(appSettingFilePath);

            //var root = config.Build();

            //var value = root
            //             .GetSection("Data")
            //             .GetSection("AppName")
            //             .Value;


            return View();
        }
    }
}
