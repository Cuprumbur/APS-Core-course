using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pluralsight.Services;

namespace Pluralsight
{
    public class Startup
    {
        private readonly IWebHostEnvironment webHostingEnvironment;
        public Startup(IWebHostEnvironment webHostingEnvironment)
        {
            this.webHostingEnvironment = webHostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeting, Greeting>();
            services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            IMvcBuilder mvcBuilder = services.AddMvc(options => options.EnableEndpointRouting = false);

            if (webHostingEnvironment.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IGreeting greeting)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(GetConfigureRoutes);

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not found");
            });
        }

        private void GetConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
