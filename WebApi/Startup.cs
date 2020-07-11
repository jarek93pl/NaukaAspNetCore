using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApi
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
            services.AddControllers();
            //AddXmlDataContractSerializerFormatters dododaje do obsugiwanych xml w header) accept=application/xml
            //w³¹czenie tej opcji option.ReturnHttpNotAcceptable = true;, blokuje zwrócenie accept=application/html, które i tak by zwróci³o dane w jakimœ innym formacie np. json 
            services.AddMvc().AddXmlDataContractSerializerFormatters().AddMvcOptions(option =>
            {
                option.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
                option.ReturnHttpNotAcceptable = true;
                option.RespectBrowserAcceptHeader = true;
            }); ;

            //services.AddMvc().set
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
