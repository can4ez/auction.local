using auction.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auction
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                    });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
                DatabaseConnections.OrganizationsCatalogDB = new OrganizationsCatalogDBContext(Configuration["ConnectionStrings:CityOrganizationsCatalogDB"]);
            }

        [Obsolete]
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                    app.UseDeveloperExceptionPage();

            // Add header:
            /*app.Use((context, next) =>
            {
                //context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                return next.Invoke();
            });*/

            app.UseMvc();
            }
        }
    }
