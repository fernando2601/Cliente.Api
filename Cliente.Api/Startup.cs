using Infraestructure;
using Infraestructure.Bus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddInjectionService();
            services.AddAutoMapperConfiguration();
            services.AddInjectionRepository();
            // In production, the Angular files will be served from this directory
            services.AddDbContext<ClienteDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalDb")));
            services.AddDbContext<EventStoreSqlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalDb")));


            services.AddMediatR(typeof(RegisterClienteCommand).GetTypeInfo().Assembly);

            services.AddSwaggerConfiguration();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }

}