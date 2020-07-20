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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityZNetCore.Models;
using IdentityZNetCore.Validator;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace IdentityZNetCore
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
            services.AddDbContext<ContextDBIdentity>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("DBIdentity") ?? $"Data Source=DESKTOP-NO39NB8\\MSSQLSERVER01;Initial Catalog=EFIDENTITY;Integrated Security=True"));
            services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequireDigit = false;
                option.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ContextDBIdentity>().AddDefaultTokenProviders().AddUserValidator<UserValidator>().AddPasswordValidator<PasswordValidator>();
            //AddDefaultTokenProviders

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            services.AddAuthorization(option =>
            {
                option.AddPolicy("UrzytkownikZWawy", policy =>
                 {
                     policy.RequireRole("WW");
                     policy.RequireClaim(LocationClaimsProvider.NameClaimToRegion, Region.Mazowieckie.ToString());
                     policy.AddRequirements(new ForJarekRequirement());
                 });
            }
            );
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "YourAppCookieName";
                options.SlidingExpiration = true;
            });

            services.AddTransient<IAuthorizationHandler, ForJarekHandler>();// po za typem ma znaczenie jaki interfej siê wstrzuje 
            services.AddScoped<IClaimsTransformation, LocationClaimsProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ///kolejnoœæ ma znaczeni !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            app.UseAuthentication();
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
            //app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
