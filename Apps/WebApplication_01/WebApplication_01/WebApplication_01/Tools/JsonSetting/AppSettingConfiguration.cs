using System.IO;
using Microsoft.Extensions.Configuration;
using WebApplication_01.AppConsts;

namespace WebApplication_01.Tools.JsonSetting
{
    public class AppSettingConfiguration
    {
        public static IConfigurationRoot GetRoot()
        {
            var config = new ConfigurationBuilder();

            config.AddJsonFile(AppSettingFilePath);

            return config.Build();
        }

        private static string AppSettingFilePath => Path.Combine(
                                                    Directory.GetCurrentDirectory(),
                                                    AppSettingConsts.AppSettingFileName);

    }
}
