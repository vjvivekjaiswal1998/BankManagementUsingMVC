using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleWare
{
    public class DemoMiddleWare
    {
        //public static void Configure(IApplicationBuilder app)
        //    {
        //        app.Use(async (context, next) =>
        //        {
        //            // Do work that doesn't write to the Response.
        //            await next.Invoke();
        //            // Do logging or other work that doesn't write to the Response.
        //        });

        //        app.Run(async context =>
        //        {
        //            string v = "Hello I am Vivek.\n thanks for visiting my page,\n";
        //            string a = "asdfghjkl";
        //            string b = "abcd";
 
        //             await context.Response.WriteAsync(v);
        //            await context.Response.WriteAsync(a);
        //            await context.Response.WriteAsync("1234");
        //        });
        //    }
        public static void Configure1(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                // Do work that doesn't write to the Response.
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });

            app.Run(async context =>
            {
                string v = "Hello I am Vicky.\n thanks for visiting my page,\n";
                string a = "asdfghjkl";

                await context.Response.WriteAsync(v);
                await context.Response.WriteAsync(a);
            });
        }

        public static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
               // app.Map("/map2", HandleMapTest2);
            });
        }

        public static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 2");
            });
        }

        public static void HandleMapTest3(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello I am Vicky.<br /> thanks for visiting my page,<br />");

            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.Map("/map1", HandleMapTest1);

            app.Map("/map2", HandleMapTest2);
            app.Map("/map3", HandleMapTest3);
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from non-Map delegate. <p>");
            });
        }
    }
}
