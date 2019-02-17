using AutoMapper;
using DemoCore.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoCore.WebAPI.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            var config = AutoMapperConfig.RegisterMappings();
        }
    }
}
