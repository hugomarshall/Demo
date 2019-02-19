using DemoCore.Infra.CrossCutting.Identity.Authorization;
using DemoCore.Infra.CrossCutting.Identity.Data;
using DemoCore.Infra.CrossCutting.Identity.Models;
using DemoCore.Infra.CrossCutting.IoC;
using DemoCore.WebUI.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCore.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => {
                    o.LoginPath = new PathString("/login");
                    o.AccessDeniedPath = new PathString("/home/access-denied");
                })
                .AddFacebook(o =>
                {
                    o.AppId = Configuration["Authentication:Facebook:AppId"];
                    o.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAutoMapperSetup();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseNodeModules(env);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootstrapper.RegisterServices(services);
        }
    }
}
