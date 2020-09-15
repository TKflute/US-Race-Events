using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06EFCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace Lab06EFCore
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.AddDbContext<RaceEventsDbContext>(options => options.UseSqlServer(connection));

            services.AddDbContext<RaceEventsDbContext>(
                    options => options.UseSqlServer(Configuration["Data:RaceEventsData:ConnectionString"]));

            services.AddTransient<IRaceRepository, EFRaceRepository>();
            services.AddTransient<IRunnerRepository, EFRunnerRepository>();
            services.AddTransient<IRunRepository, EFRunRepository>();
            services.AddTransient<IRegistrationRepository, EFRegistrationRepository>();
            
            services.AddTransient<ISponsorApplicationRepository, EFSponsorApplicationRepository>();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RaceEventsDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            { 
               routes.MapRoute(
                         name: null,
                         //this is uri
                         template: "{category}/Page{pageId:int}",
                         defaults: new { controller = "Race", action = "List" }
                );
                /*
                routes.MapRoute(
                    name: null,
                    template: "Page{pageId:int}",
                    defaults: new { controller = "Runner", action = "List", pageId = 1 }
                );*/

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Race", action = "List", pageId = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Race", action = "List", pageId = 1 }
                );

                routes.MapRoute(name: "null", template: "{controller}/{action}/{id?}");

        });

            //SeedData.EnsurePopulated(context);
        }
    }
}
