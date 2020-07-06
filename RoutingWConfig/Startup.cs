using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
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
        enum en { poniedzia³ek, wtorek, sieroda, czwartek, piatek, sobota, niedziela };
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("Weekdey", typeof(customselector));
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
        }
        class VirtualPathRouter : IRouter
        {
            public readonly string textToUse;
            public VirtualPathRouter(string TextToUse)
            {
                textToUse = TextToUse;
            }
            public VirtualPathData GetVirtualPath(VirtualPathContext context)
            {
                if (context.HttpContext.Request.Path.ToString().Contains(textToUse))
                {
                    return new VirtualPathData(this, "Api2/Home2Controller/Daria");
                }
                else
                {
                    return null;
                }
            }

            public Task RouteAsync(RouteContext context)
            {
                return Task.CompletedTask;
            }
        }

        class ConstTextRouter : IRouter
        {
            public readonly string textToUse;
            public ConstTextRouter(string TextToUse)
            {
                textToUse = TextToUse;
            }
            public VirtualPathData GetVirtualPath(VirtualPathContext context)
            {
                return null;
            }

            public Task RouteAsync(RouteContext context)
            {
                if (context.HttpContext.Request.Path.ToString().Contains(textToUse))
                {
                    return context.HttpContext.Response.WriteAsync("z routingu");
                }
                return Task.CompletedTask;
            }
        }
        class customselector : IRouteConstraint
        {
            string[] days = new string[] { "poniedzialek", "wtorek", "sieroda", "czwartek", "pi¹tek", "sobota", "niedziela" };
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
            {
                return days.Any(X => httpContext.Request.Path.ToString().Contains(X));
            }
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

                /* https://localhost:5001/Api/Home/Darek/33/poniedzialek */
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "Api/{controller=Home}/{action=Index}/{id:int}/{idx:Weekdey}");


                /* https://localhost:5001/Api2/Home/Darek/33/poniedzialek */
                endpoints.MapControllerRoute(
                    name: "nam",
                    pattern: "Api2/{controller=Home}/{action=Index}/{id:int}/{idx:Weekdey}");


                /* https://localhost:5001/Api2/Home/Darek/33/poniedzialek */
                endpoints.MapControllerRoute(
                    name: "nam",
                    pattern: "Api2/{controller=Home}/{action=Index}/{id:int}/{idx:Weekdey}");

                /* https://localhost:5001/Api3 */
                endpoints.MapGet("api3", x => x.Response.WriteAsync("text z api3"));


            });
        }
    }
}
