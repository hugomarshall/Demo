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
            services.AddScoped<IBestWorkTimeService, BestWorkTimeService>();
            services.AddScoped<IDesignerService, DesignerService>();
            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IWorkAvailabilityService, WorkAvailabilityService>();
            

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<PeopleRegisteredEvent>, PeopleEventHandler>();
            services.AddScoped<INotificationHandler<PeopleUpdatedEvent>, PeopleEventHandler>();
            services.AddScoped<INotificationHandler<PeopleRemovedEvent>, PeopleEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewPeopleCommand, bool>, PeopleCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePeopleCommand, bool>, PeopleCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePeopleCommand, bool>, PeopleCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewBestWorkTimeCommand, bool>, BestWorkTimeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateBestWorkTimeCommand, bool>, BestWorkTimeCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveBestWorkTimeCommand, bool>, BestWorkTimeCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewDesignerCommand, bool>, DesignerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateDesignerCommand, bool>, DesignerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveDesignerCommand, bool>, DesignerCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewDeveloperCommand, bool>, DeveloperCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateDeveloperCommand, bool>, DeveloperCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveDeveloperCommand, bool>, DeveloperCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewWorkAvailabilityCommand, bool>, WorkAvailabilityCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateWorkAvailabilityCommand, bool>, WorkAvailabilityCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveWorkAvailabilityCommand, bool>, WorkAvailabilityCommandHandler>();


            // Infra - Data
            services.AddScoped<IBestWorkTimeRepository, BestWorkTimeRepository>();
            services.AddScoped<IDesignerRepository, DesignerRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IKnowledgeDesignerRepository, KnowledgeDesignerRepository>();
            services.AddScoped<IKnowledgeDeveloperRepository, KnowledgeDeveloperRepository>();
            services.AddScoped<IKnowledgeRepository, KnowledgeRepository>();
            services.AddScoped<IOccupationBestWorkTimeRepository, OccupationBestWorkTimeRepository>();
            services.AddScoped<IOccupationWorkAvailabilityRepository, OccupationWorkAvailabilityRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IWorkAvailabilityRepository, WorkAvailabilityRepository>();
            
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
