using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titan.BL.Contracts;
using Titan.BL.Implementations;
using Titan.Core.AutomapperProfiles;
using Titan.Core.Security;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;
using Titan.DAL.Repositories.Implementations;

namespace Titan.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public CorsPolicy GenerateCorsPolicy()
        {
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            return corsBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            services.AddControllers();
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", GenerateCorsPolicy());
            });



            AddSwagger(services);

            services.AddAutoMapper(cfg => cfg.AddProfile(new AutomapperProfile()));

            services.AddScoped<IEmpresaBL, EmpresaBL>();

            services.AddScoped<IUsuarioBL, UsuarioBL>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ILoginRepository, LoginRepository>();

            services.AddScoped<IPasswordGenerator, PasswordGenerator>();

            services.AddScoped<IProvinciaBL, ProvinciaBL>();

            services.AddScoped<IProvinciaRepository, ProvinciaRepository>();

            services.AddScoped<IOfferBL, OfferBL>();

            services.AddScoped<IOfferRepository, OfferRepository>();

            services.AddScoped<ICicloBL, CicloBL>();
            
            services.AddDbContext<pitufoContext>(opts => opts.UseMySql(Configuration["ConnectionString:PitufoDB"],
                ServerVersion.AutoDetect(Configuration["ConnectionString:PitufoDB"])));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            app.UseRouting();
            app.UseCors("AllowAllOrigins");
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Foo {groupName}",
                    Version = groupName,
                    Description = "Foo API",
                    Contact = new OpenApiContact
                    {
                        Name = "Foo Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }
    }
}
