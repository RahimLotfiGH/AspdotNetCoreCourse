using WebApplication_01.AppConsts;

namespace WebApplication_01.Tools.JsonSetting
{
    public class AppSetting
    {
        public static string AppName => AppSettingConfiguration
                                          .GetRoot()
                                          .GetSection(AppSettingConsts.Data)
                                          .GetSection(AppSettingConsts.AppName)
                                          .Value;

        public static string Site => AppSettingConfiguration
                                        .GetRoot()
                                        .GetSection(AppSettingConsts.Data)
                                        .GetSection(AppSettingConsts.Site)
                                        .Value;

    }
}
