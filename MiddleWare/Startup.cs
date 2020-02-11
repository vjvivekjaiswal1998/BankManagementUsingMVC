using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MiddleWare
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            // DemoMiddleWare.Configure(app);
            //  DemoMiddleWare.Configure1(app);
            
            app.UseMiddleware();
            app.UseMvc(router =>
            {
                router.MapRoute(
                    name: "default",
                    template: "{controller=vicky}/{action=Index}/{id?}");
            });

            //      app.UseMvc(routes =>
            //      {
            //          routes.MapRoute(
            //name: "default",
            //template: "Test/{*Index}",
            //defaults: new { controller = "Test", action = "list" });
            //      });

            //  app.UseMvc();
            var trackPackageRouteHandler = new RouteHandler(context =>
            {
                var routeValues = context.GetRouteData().Values;
                return context.Response.WriteAsync(
                    $"Hello! Route values: {string.Join(", ", routeValues)}");
            });

            var routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);

            routeBuilder.MapRoute(
                "Track Package Route",
                "package/{operation:regex(^track|create$)}/{id:int}");

            routeBuilder.MapGet("vicky/{*name}", context =>
            {
                var name = context.GetRouteValue("name");
                // The route handler when HTTP GET "hello/<anything>" matches
                // To match HTTP GET "hello/<anything>/<anything>, 
                // use routeBuilder.MapGet("hello/{*name}"
                return context.Response.WriteAsync($"Hi from map get, {name}!");
            });

            routeBuilder.MapPut("vicky/{*name}", context =>
            {
                var name = context.GetRouteValue("name");
                return context.Response.WriteAsync($"Hi from map put , {name}!");
            });

            routeBuilder.MapPost("vicky/{*name}", context =>
            {
                var name = context.GetRouteValue("name");
                return context.Response.WriteAsync($"Hi from map post , {name}!");
            });
            routeBuilder.MapDelete("vicky/{*name}", context =>
            {
                var name = context.GetRouteValue("name");
                return context.Response.WriteAsync($"Hi from mapdelete  , {name}!");
            });
          
            //routeBuilder.MapMiddlewareGet("vicky/{*name}", context =>
            //{
            //    var name = context.GetRouteValue("name");
            //    return context.Response.WriteAsync($"Hi, {name}!");
            //});
            var routes = routeBuilder.Build();
            app.UseRouter(routes);
        }
    }
}
