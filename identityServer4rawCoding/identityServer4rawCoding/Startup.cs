using identityServer4rawCoding.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identityServer4rawCoding
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(config => {
                config.UseInMemoryDatabase("Memory");
            });
            services.AddDbContext<AppDbContext>();
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(config => {
                config.Cookie.Name = "IdentityServer.Cookie";
                config.LoginPath = "/Home/Login";
            });
            services.AddIdentityServer()
                .AddAspNetIdentity<IdentityUser>()
                //.AddInMemoryApiResources(Configuration.GetApis())
                .AddInMemoryApiScopes(Configuration.GetApiScopes())
                .AddInMemoryClients(Configuration.GetClients())
                .AddDeveloperSigningCredential();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
