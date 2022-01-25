using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.BL.Contracts;
using Titan.BL.Implementations;
using Titan.Core.AutomapperProfiles;
using Titan.Core.Email;
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

            string[] exposedheader = { "Authorization" };
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", o=>{

                    o.WithOrigins("http://localhost:4200");
                    o.AllowAnyHeader();
                    o.AllowAnyMethod();
                    o.AllowCredentials();
                    o.WithExposedHeaders(exposedheader);
            });
                
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
                };
            });
            services.AddAuthorization(config =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                config.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
                //config.AddPolicy(Policies.EMPRESA, policy => { policy.RequireClaim("Role", Policies.EMPRESA); });
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

            services.AddScoped<ICicloRepository, CicloRepository>();

            services.AddScoped<IInscripcionesBL, InscripcionesBL>();

            services.AddScoped<IInscripcionesRepository, InscripcionesRepository>();

            services.AddScoped<IFamiliaBL, FamiliaBL>();

            services.AddScoped<IFamiliaRepository, FamiliaRepository>();

            services.AddScoped<ITipoCicloBL, TipoCicloBL>();

            services.AddScoped<ITipoCicloRepository, TipoCicloRepository>();

            services.AddScoped<IOfertaCicloBL, OfertaCicloBL>();

            services.AddScoped<IOfertaCicloRepository, OfertaCicloRepository>();

            services.AddScoped<IJwtBearer, JwtBearer>();

            services.AddScoped<IEmailSender, EmailSender>();


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
            app.UseAuthentication();


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

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });


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
