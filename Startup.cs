using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //service that tells asp.net to use the MVC pattern. 
            services.AddControllersWithViews();

            services.AddDbContext<BookContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:BookDBConnection"]);
           });

            services.AddScoped<IBookRepository, EFBookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //tell asp.net to use the static files in the wwwroot folder
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //to follow controller -> action -> ID
                //This is different than other default settings, something like: pattern: "{controller:..}{Route:...}{id=?}"
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
