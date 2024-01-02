using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestIdentityWebApplication.Areas.Identity.Data;
using TestIdentityWebApplication.Data;

[assembly: HostingStartup(typeof(TestIdentityWebApplication.Areas.Identity.IdentityHostingStartup))]
namespace TestIdentityWebApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestIdentityContextConnection")));

                services.AddDefaultIdentity<Person>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TestIdentityContext>();
            });
        }
    }
}