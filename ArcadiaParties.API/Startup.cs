using ArcadiaParties.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ArcadiaParties.Data.Data;
using Microsoft.AspNetCore.Authentication.Negotiate;
using ArcadiaParties.API.CustomMiddlewares;
using ArcadiaParties.CQRS.Commands;
using ArcadiaParties.Data.Repositories;
using AutoMapper;
using ArcadiaParties.Data.Abstractions.Repositories;
using ArcadiaParties.Data.Helpers;
using System;

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ArcadiaParties.API", Version = "v1" });
                c.EnableAnnotations();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://login.microsoftonline.com/958661cb-2cde-47d5-814e-5be2619d3fde/oauth2/authorize"),
                            TokenUrl = new Uri("https://login.microsoftonline.com/fa4e9c1f-6222-443d-a083-28f80c1ffefc/oauth2/token"),
                        }
                        
                    }
                });
            });

            services.AddMediatR(typeof(SeedCommand).Assembly);

            services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ArcadiaParties API V1");
                c.OAuthClientId("3041149d-3071-4f8e-8df7-4ff59545cfeb");
                c.OAuth2RedirectUrl("http://localhost:63601/swagger/o2c.html");
            });

            //app.UseSwaggerUI(
            //    c =>
            //    {
            //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Arcadian-Assistant API");
            //        c.ShowJsonEditor();
            //        c.ShowRequestHeaders();
            //        c.ConfigureOAuth2(
            //            securitySettings.ClientId,
            //            null,
            //            securitySettings.SwaggerRedirectUri,
            //            "ArcadiaAssistant",
            //            additionalQueryStringParameters: new Dictionary<string, string>() { { "resource", securitySettings.ClientId } }
            //            );
            //    });

            app.UseRouting();

            app.UseAuthentication();

            app.UseDatabaseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
