using ASP_с_бд.AuthTelephoneDescriptionApp;
using ASP_с_бд.ContextData;
using ASP_с_бд.Data;
using ASP_с_бд.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_с_бд
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ITelephoneDescriptionData, TelephoneDescriptionData>();
            //services.AddSpaStaticFiles();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            #region//
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;// минимальное количество знаков в пароле
  
                options.Lockout.MaxFailedAccessAttempts = 10; //количество попыток до блокировки
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                //конфигурация Cookie с целью использования их для  хранения авторизации
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login"; // где находится логика залогинивания
                options.LogoutPath = "/Account/Logout";// где логика выхода
                options.SlidingExpiration = true;
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(
                r =>
                {
                    r.MapRoute(
                        name: "default",
                        template:"{controller=TelephoneDescription}/{action=AllView}");
                    //r.MapRoute("default", "{controller=telephone}/{action=Index}");
                }
                );
        }
    }
}
