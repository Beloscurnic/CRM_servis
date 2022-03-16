
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using CRM.Application.Common.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CRM.Application.Interfaces;
using CRM.Application;
using CRM.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using CRM.WebApi.Middleware;
using System.IO;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Authorization;

namespace CRM.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
     
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(ICRM_DbContext).Assembly));
            });
           // services.AddMvc();
            //services.AddMediatR(typeof(Startup));
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddCors();
            services.AddControllers();
        //    var guestPolicy = new AuthorizationPolicyBuilder()
        //.RequireAuthenticatedUser()
        //.RequireClaim("scope", "CRM_Role")
        //.Build();
            //конфигураци€ аунтентификации 
            services.AddAuthentication(config =>
            {
                //«начение по умолчанию дл€ свойства AuthenticationScheme в JwtBearerAuthenticationOptions
                config.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               //јутентификаци€ носител€ JWT выполн€ет аутентификацию, извлека€ и провер€€ токен JWT из Authorization заголовка запроса.
               .AddJwtBearer("Bearer", options =>
               {                   options.Authority = "https://localhost:44335/";
                   options.Audience = "CRMWebAPI";
                   options.RequireHttpsMetadata = false;
               });

            services.AddVersionedApiExplorer(options =>
                 options.GroupNameFormat = "'v'VVV");

            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy => policy
                   .RequireAuthenticatedUser()
                   .RequireRole("admin"));

            });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
                    ConfigureSwaggerOtions>();
            services.AddSwaggerGen();
            services.AddApiVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
          IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    config.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                    config.RoutePrefix = string.Empty;
                }
            });

            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors(x => x
             .WithOrigins("https://localhost:3000")
             .AllowAnyMethod()
             .AllowAnyHeader()
             .SetIsOriginAllowed(origin => true) // allow any origin
             .AllowCredentials()); // allow credentials
      
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseApiVersioning();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
