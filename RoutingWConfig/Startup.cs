using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RoutingWConfig
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

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                /*https://localhost:5001/Home/Daria */
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");

                /* https://localhost:5001/XHome/Daria */
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "X{controller=Home}/{action=Index}");


                /* https://localhost:5001/Api/Home/Daria */
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "Api/{controller=Home}/{action=Index}");


                /* https://localhost:5001/Api/Home/Daria/3 */
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "Api/{controller=Home}/{action=Index}/{id?}");


                /* https://localhost:5001/Api/Home/Daria/gre/grreg/gregre/regreg/regre/regr/egregreg/rgeeg */
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "Api/{controller=Home}/{action=Index}/{*id}");


                /* https://localhost:5001/Api/Home/Darek/33/Sss*/
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "Api/{controller=Home}/{action=Index}/{id:int}/{idx:regex(^S)}");
            });
        }
    }
}
