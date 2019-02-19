using AutoMapper;
using DemoCore.Application.AutoMapper;
using DemoCore.Infra.CrossCutting.Identity.Data;
using DemoCore.Infra.CrossCutting.IoC;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoCore.Tests.XUnitTestProject
{
    public class Startup
    {
        private static bool _initialized = false;
        private IConfiguration Configuration { get; }
        private ServiceCollection serviceCollection = new ServiceCollection();

        public Startup()
        {
            if (_initialized)
            {
                Mapper.Reset();
            }

            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false)
                .Build();

            ConfigureServices(serviceCollection);
            _initialized = true;
            
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton(new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(typeof(DomainToViewModelMappingProfile)))));
            services.AddSingleton(new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(typeof(ViewModelToDomainMappingProfile)))));

            //AutoMapperConfig.RegisterMappings();
            services.AddAutoMapper(typeof(Startup));
            
            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootstrapper.RegisterServices(services);
        }

        public ServiceProvider GetServiceProvider()
        {
            return serviceCollection.BuildServiceProvider();
        }

    }

}
