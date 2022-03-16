using CRM.Identity.Data;
using CRM.Identity.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Identity
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration AppConfiguration { get; }

        public Startup(IConfiguration configuration) => AppConfiguration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = AppConfiguration.GetValue<string>("Data_Base");
            services.AddDbContext<Identity_Context>(option =>
           {
               option.UseSqlServer(connectionString);
                });

            var connectionString2 = AppConfiguration.GetValue<string>("Data_Base2");
            services.AddDbContext<CRM_Context>(option =>
            {
                option.UseSqlServer(connectionString2);
            });

            services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<Identity_Context>()
                .AddDefaultTokenProviders();
            services.AddTransient<IProfileService, IdentityWithAdditionalClaimsProfileService>();
            //����������� IdentutyServer � ���� ��������� ��������� ����������� �������� AddIdentityServer
            services.AddIdentityServer()
                //����� ���������� � IdentityServer, ����������� ��� �������� ����������������� ������, ����� ���� ������������ ����� �������� ����������� � ������.
                .AddAspNetIdentity<AppUser>()
                //���������� ������ API.
                .AddInMemoryApiResources(Configuration.ApiResources)
                //���������� ���������� ������ ��������� �������� �������������. �.�. �������� ������, �� ������� ����� ����� ��������� �������.
                .AddInMemoryIdentityResources(Configuration.IdentityResources)
                // ���������� ������������ ������������ ������� �������� OAuth
                .AddInMemoryApiScopes(Configuration.ApiScopes)
                //������� ������������ ����� ����������, ������� ����� ����������� ������ � ������ ������� �������������.
                .AddInMemoryClients(Configuration.Clients)
                // ������� ��������� �������� �������� �� ����� �������. ��� ��� ��������� ����������. ��������������� ���� ����� �������� � ��������� �������� �� ���������.
                .AddDeveloperSigningCredential()
                .AddProfileService<IdentityWithAdditionalClaimsProfileService>();


            //����������� ���� cookie ����������.
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "CRM.Identity.Cookie";
                config.LoginPath = "/Auth/Login";
                config.LogoutPath = "/Auth/Logout";
            });

           services.AddControllersWithViews();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "Styles")),
                RequestPath = "/styles"
            });

            app.UseRouting();

            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
