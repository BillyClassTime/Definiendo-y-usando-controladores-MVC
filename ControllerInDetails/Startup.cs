using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerInDetails.Models;
namespace ControllerInDetails
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISimpleModel, SimpleModel>();
            services.AddMvc(); //Uso del Patron MVC
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvcWithDefaultRoute(); // Para que encuentre las rutas MVC por defectos
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:"default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Another", action = "AnotherAction" });
            });


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Paginillas no encontradas :)");
            });
        }
    }
}
