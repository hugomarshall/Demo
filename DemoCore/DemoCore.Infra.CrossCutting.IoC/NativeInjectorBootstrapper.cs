using DemoCore.Application.Interfaces;
using DemoCore.Application.Services;
using DemoCore.Domain.CommandHandlers;
using DemoCore.Domain.Commands;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Core.Events;
using DemoCore.Domain.Core.Notifications;
using DemoCore.Domain.EventHandlers;
using DemoCore.Domain.Events;
using DemoCore.Domain.Interfaces;
using DemoCore.Infra.CrossCutting.Bus;
using DemoCore.Infra.CrossCutting.Identity.Authorization;
using DemoCore.Infra.CrossCutting.Identity.Models;
using DemoCore.Infra.CrossCutting.Identity.Services;
using DemoCore.Infra.Data.Context;
using DemoCore.Infra.Data.EventSourcing;
using DemoCore.Infra.Data.Repositories;
using DemoCore.Infra.Data.Repositories.EventSourcing;
using DemoCore.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;



namespace DemoCore.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IDeveloperService, DeveloperService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<PeopleRegisteredEvent>, PeopleEventHandler>();
            services.AddScoped<INotificationHandler<PeopleUpdatedEvent>, PeopleEventHandler>();
            services.AddScoped<INotificationHandler<PeopleRemovedEvent>, PeopleEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewPeopleCommand>, PeopleCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePeopleCommand>, PeopleCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePeopleCommand>, PeopleCommandHandler>();

            // Infra - Data
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DemoCoreContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
