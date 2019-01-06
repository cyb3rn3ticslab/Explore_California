using System;
using Explore_California.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Explore_California
{
    public class Startup
    {
        private readonly IConfigurationRoot configuration;

        //public Startup(IHostingEnvironment env)
        //{

        //}


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddTransient<FormattingService>();

            services.AddDbContext<BlogDataContext>(options =>
            {
                string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ExploreCalifornia;Trusted_Connection=True;";  //configuration.GetConnectionString("BlogDataContext");
                options.UseSqlServer(connectionString);
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseExceptionHandler("/error.html");
            //app.UseStaticFiles();

             //var configuration = new ConfigurationBuilder()
             //                       .AddEnvironmentVariables()
             //                       .AddJsonFile(env.ContentRootPath + "/config.json")
             //                       .Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseMvc(routes =>
            {
                routes.MapRoute("Default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseFileServer();
        }
    }
}
