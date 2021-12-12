using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
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
            services.AddControllers();

            // adding swagger generation
            services.AddSwaggerGen();

            // adding automapper
            services.AddAutoMapper(typeof(Startup));
            
            // adding in memory DataBase for EF
            services.AddDbContext<BreweryManagementContext>(opt =>
               opt.UseInMemoryDatabase("BreweryManagement"));

            // manage dependency injection
            services.AddScoped<IBeerService, BeerService>();
            services.AddScoped<IBeerRepository, BeerRepository>();
            services.AddScoped<IBreweryService, BreweryService>();
            services.AddScoped<IBreweryRepository, BreweryRepository>();
            services.AddScoped<IWholesalerService, WholesalerService>();
            services.AddScoped<IWholesalerRepository, WholesalerRepository>();
            services.AddScoped<IWholesalerStockRepository, WholesalerStockRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
