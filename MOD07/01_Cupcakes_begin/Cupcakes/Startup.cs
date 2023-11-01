using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupcakes.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cupcakes.Repositories;

namespace Cupcakes
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Server=localhost;Database=BakeriesDb;Trusted_Connection=True;MultipleActiveResultSets=true";

            services.AddTransient<ICupcakeRepository, CupcakeRepository>();
            //services.AddDbContext<CupcakeContext>(options => options.UseSqlite("Data Source=cupcake.db"));
            services.AddDbContext<CupcakeContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            
        }

        public void Configure(IApplicationBuilder app, CupcakeContext cupcakeContext)
        {
            //cupcakeContext.Database.EnsureDeleted();
            //cupcakeContext.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CupcakeRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Cupcake", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
