using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DemoCore.Infra.CrossCutting.Identity.Authorization;
using DemoCore.Infra.CrossCutting.Identity.Data;
using DemoCore.Infra.CrossCutting.Identity.Migrations;
using DemoCore.Infra.CrossCutting.Identity.Models;
using DemoCore.Infra.CrossCutting.IoC;
using DemoCore.Infra.Data.Context;
using DemoCore.Infra.Data.Migrations;
using DemoCore.WebAPI.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace DemoCore.WebApi
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                //builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
            });

            services.AddAutoMapperSetup();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanReadPeopleData", policy => policy.Requirements.Add(new ClaimRequirement("People", "Read")));
                options.AddPolicy("CanWritePeopleData", policy => policy.Requirements.Add(new ClaimRequirement("People", "Write")));
                options.AddPolicy("CanRemovePeopleData", policy => policy.Requirements.Add(new ClaimRequirement("People", "Delete")));

                options.AddPolicy("CanReadBestWorkTimeData", policy => policy.Requirements.Add(new ClaimRequirement("BestWorkTime", "Read")));
                options.AddPolicy("CanWriteBestWorkTimeData", policy => policy.Requirements.Add(new ClaimRequirement("BestWorkTime", "Write")));
                options.AddPolicy("CanRemoveBestWorkTimeData", policy => policy.Requirements.Add(new ClaimRequirement("BestWorkTime", "Delete")));

                options.AddPolicy("CanReadDesignerData", policy => policy.Requirements.Add(new ClaimRequirement("Designer", "Read")));
                options.AddPolicy("CanWriteDesignerData", policy => policy.Requirements.Add(new ClaimRequirement("Designer", "Write")));
                options.AddPolicy("CanRemoveDesignerData", policy => policy.Requirements.Add(new ClaimRequirement("Designer", "Delete")));

                options.AddPolicy("CanReadDeveloperData", policy => policy.Requirements.Add(new ClaimRequirement("Developer", "Read")));
                options.AddPolicy("CanWriteDeveloperData", policy => policy.Requirements.Add(new ClaimRequirement("Developer", "Write")));
                options.AddPolicy("CanRemoveDeveloperData", policy => policy.Requirements.Add(new ClaimRequirement("Developer", "Delete")));

                options.AddPolicy("CanReadWorkAvailabilityData", policy => policy.Requirements.Add(new ClaimRequirement("WorkAvailability", "Read")));
                options.AddPolicy("CanWriteWorkAvailabilityData", policy => policy.Requirements.Add(new ClaimRequirement("WorkAvailability", "Write")));
                options.AddPolicy("CanRemoveWorkAvailabilityData", policy => policy.Requirements.Add(new ClaimRequirement("WorkAvailability", "Delete")));
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "DemoCore Project",
                    Description = "DemoCore API",
                    Contact = new Contact { Name = "Hugo Terra", Email = "hugo@sharpnet.com.br", Url = "http://www.sharpnet.com.br" }
                });
            });

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            services.AddMvc(options =>
            {
                //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());   //Only in Presentation
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor accessor, DemoCoreContext context, ApplicationDbContext identityContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            //app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoCore Project API v1.0");
            });

            new DemoCoreDbInitializer(context).Seed().Wait();
            new IdentityDbInitializer(identityContext, userManager, roleManager).Seed();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootstrapper.RegisterServices(services);
        }
    }
}
