using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Tutorial.Business.Services;
using Tutorial.Domain.Context;
using Tutorial.Domain.Services;
using Tutorial.Services;
using Tutorial.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Tutorial
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionSring = Configuration.GetConnectionString("TutorialDatabase");
            services.AddControllers();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<CallerService>();
            services.AddSingleton<SingletonService>();
            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();
            services.AddDbContext<TutorialDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TutorialDatabase")));
      


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
                endpoints.MapControllers();
            });
        }
    }
}
