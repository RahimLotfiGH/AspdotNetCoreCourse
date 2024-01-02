using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication_01.AppCode.Contracts;
using WebApplication_01.AppCode.Services;

namespace WebApplication_01
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();


            services.AddScoped<ICalcService, CalcService>();
            //services.AddSingleton<ICalcService, CalcService>();
            //services.AddTransient<ICalcService, CalcService>();

            services.AddSingleton<IInMemoryUserAccessService>(new InMemoryUserAccessService());


            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(10);
                option.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            //var hour = DateTime.Now.Hour;

            //if (hour > 16)
            //{
            //    app.Run(async (context) =>
            //           {
            //               context.Response.ContentType = "text/plain; charset=utf-8";
            //               await context
            //                   .Response
            //                   .WriteAsync("در این ساعت درخواست شما قادر به پردازش نیست");
            //           });
            //}


            //app.Use(async (context,next) =>
            //{
            //    if (context.Request.Query.ContainsKey("UserName"))
            //    {
            //        await context.Response.WriteAsync("No Access");
            //    }

            //    await next.Invoke();
            //});

            //app.UseMiddleware<TestMiddleware>();

            // app.UseTestMiddleware();

            //app.Map("/home", (builder) =>
            //{
            //    //builder.Use()
            //    //builder.Run();
            //});

            //app.MapWhen(context => context.Request.Query.ContainsKey("userName")

            //, builder =>
            //{
            //    // builder.Use()
            //});

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
