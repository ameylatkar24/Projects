using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Catlog.Management.Api.Buisness.Repository;
using Catlog.Management.Api.Repository.Repositories;
using Microsoft.Extensions.Options;
using Catlog.Management.Api.Repository.Infrastructure;
using Catlog.Management.Api.Buisness.Infrastructure;
using AutoMapper;
using Catlog.Management.Api.Buisness.Mapper;

namespace Catlog.Management.Api
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
            services.Configure<CatlogDatabaseSettings>(Configuration.GetSection(nameof(CatlogDatabaseSettings)));

            services.AddSingleton<ICatlogDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CatlogDatabaseSettings>>().Value);

            services.AddTransient<ICatlogContext, CatlogContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICatlogBuisness, CatlogBuisness>();
            //services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<MapperClass>(), typeof(Startup));




            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catlog.Management.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catlog.Management.Api v1"));
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
