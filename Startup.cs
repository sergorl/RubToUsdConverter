using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

using Util;
using Contract;


namespace aspnetcoreapp
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
            services.AddRazorPages();
        }

        // This method gets called by the rundatetime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
         
            app.Map("/log", appBuilder => {
                appBuilder.Run( async context =>
                    {
                        var pathToLog = context.Request.Query["file"].ToString();
                        var log = string.Join("\n", System.IO.File.ReadAllLines(pathToLog));
                        await context.Response.WriteAsync($"Result of route /log - content of {pathToLog}:\n{log}");
                    }
                );
            });
        }
    }
}
