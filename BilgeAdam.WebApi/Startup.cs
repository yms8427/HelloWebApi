using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilgeAdam.WebApi.Data;
using BilgeAdam.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BilgeAdam.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddCors(options => options.AddPolicy("all", pb => { pb.AllowAnyOrigin().AllowAnyHeader(); }));
            }
            else if (Environment.IsProduction())
            {
                services.AddCors(options => options.AddPolicy("private", pb => { pb.WithOrigins("https://www.can.com").AllowAnyHeader(); }));
            }
            //services.Configure<Settings>(Configuration);
            var cnnStr = Configuration.GetSection("Database:ConnectionString").Value;
            services.AddDbContext<NorthwindContext>(builder => builder.UseSqlServer(cnnStr));
            services.AddScoped<IProductService, ProductService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            if (Environment.IsDevelopment())
            {
                app.UseCors("all");
            }
            else if (Environment.IsProduction())
            {
                app.UseCors("private");
            }
            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
