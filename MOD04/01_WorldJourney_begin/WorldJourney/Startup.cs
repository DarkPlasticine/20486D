using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WorldJourney.Filters;
using WorldJourney.Models;

namespace WorldJourney
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IData, Data>();
            services.AddScoped<LogActionFilterAttribute>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(mapRoute =>
            {
                mapRoute.MapRoute(
                    name: "TravelerRoute",
                    template: "{controller}/{action}/{name}",
                    defaults: new {controller = "Traveler", action = "Index", name = "Katie Bruce"},
                    constraints: new { name = "[A-Za-z ]+" }
                    );
                mapRoute.MapRoute(
                    name: "defaultRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Traveler", action = "Index"},
                    constraints: new { name = "[0-9]+" }
                    );
            });
        }
    }
}
