using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSpaStaticFiles();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvc(
                r =>
                {
                    r.MapRoute("default", "{controller=TelephoneDescription}/{action=AllView}");
                    //r.MapRoute("default", "{controller=telephone}/{action=Index}");
                }
                );
        }
    }
}
