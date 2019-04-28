using AutoMapper;
using Collab.Application.Profiles;
using Collab.Application.Services.Implementations;
using Collab.Application.Services.Interfaces;
using Collab.Data;
using Collab.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Collab.Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Collab")
            ));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // AutoMapper Configuration
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ApplicationUserProfile>();
                cfg.AddProfile<ArticleProfile>();
                cfg.AddProfile<HashtagProfile>();
                cfg.AddProfile<MessageProfile>();
            });
            services.AddAutoMapper();

            // ASP.NET Core Identity Configuration
            services.AddIdentity<ApplicationUser, IdentityRole<int>>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            // A lifetime of a service registered as 'Scoped' is equal to each web request
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IHashtagService, HashtagService>();
            services.AddScoped<IMessageService, MessageService>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            // Asynchronously ensure that the database for the context exists.
            // If it exists, no action is taken.
            // If it does not exist then the database and all its schema are created.
            serviceProvider.GetService<ApplicationDbContext>().Database.EnsureCreated();
        }
    }
}
