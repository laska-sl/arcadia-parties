using ArcadiaParties.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ArcadiaParties.Data.Data;
//using ArcadiaParties.API.CustomMiddlewares;
using ArcadiaParties.CQRS.Commands;
using ArcadiaParties.Data.Repositories;
using AutoMapper;
using ArcadiaParties.Data.Abstractions.Repositories;
using ArcadiaParties.Data.Helpers;
using System.Collections.Generic;
using System;
using Microsoft.OpenApi.Models;

namespace ArcadiaParties.API
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

            services.AddTransient<ISeed, Seed>();

            // Temporary use SQLite connection until set connection to Arcadia API
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Arcadia Parties API", Version = "v1" });

                c.EnableAnnotations();

                const string securityName = "oauth2";

                c.AddSecurityDefinition(securityName, new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://login.microsoftonline.com/fa4e9c1f-6222-443d-a083-28f80c1ffefc/oauth2/authorize"),
                            TokenUrl = new Uri("https://login.microsoftonline.com/fa4e9c1f-6222-443d-a083-28f80c1ffefc/oauth2/token"),
                        }
                    }
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = securityName
                            }
                        },
                        new List<string>()
                    }
                });
            });

            services.AddMediatR(typeof(SeedCommand).Assembly);

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Arcadian Parties API");
                c.OAuthClientId("a2ccb221-60e2-47b8-b28c-bf88a59f7f4a");
                c.OAuthAppName("Arcadia Parties - Swagger");
                c.OAuthAdditionalQueryStringParams(new Dictionary<string, string>() { { "resource", "a2ccb221-60e2-47b8-b28c-bf88a59f7f4a" } });
            });

            app.UseRouting();

            app.UseAuthentication();

            //app.UseDatabaseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
