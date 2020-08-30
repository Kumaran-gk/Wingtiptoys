using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wingtiptoys.DB.Models;

namespace Wingtiptoys.client
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
            services.AddControllersWithViews();

            // TO DO : If Requries, we can add Singleton and Connection string
            // services.AddSingleton<IConfiguration>(Configuration);

            var connectionstring = Configuration.GetConnectionString("WingtiptoysDB").Replace(".\\", AppDomain.CurrentDomain.BaseDirectory);
            services.AddDbContext<WingtiptoysContext>(options =>options.UseSqlServer(connectionstring));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // TO DO : Error Controller, Can be enhanced to do the logging to the file or the Database based on the need
            //  TO DO : ILogger can be used to log the Info, Debug, Error & Fatal to the file, which can be accessed via any tools
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

            // TO DO: After Routing : Authentication is next step to validate
           //  TO DO: After Authentication : Authorization needs to be added, which can be controlled via Authorize Attribute to restrict actions for the user

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapDefaultControllerRoute();
                /*
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                */
            });
        }
    }
}
