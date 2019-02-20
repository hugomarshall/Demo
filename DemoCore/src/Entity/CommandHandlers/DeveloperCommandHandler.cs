using DemoCore.Domain.Commands;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Core.Notifications;
using DemoCore.Domain.Events;
using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.CommandHandlers
{
    public class DeveloperCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewDeveloperCommand, bool>,
        IRequestHandler<UpdateDeveloperCommand, bool>,
        IRequestHandler<RemoveDeveloperCommand, bool>
    {
        private readonly IDeveloperRepository developerRepository;
        private readonly IMediatorHandler bus;

        public DeveloperCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications
            ,IDeveloperRepository developerRepository) : base(uow, bus, notifications)
        {
            this.developerRepository = developerRepository;
            this.bus = bus;
        }

        public Task<bool> Handle(RegisterNewDeveloperCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = new Developer()
            {
                DescriptionEN = request.DescriptionEN,
                DescriptionPT = request.DescriptionPT,
                EntityState = request.EntityState,
                DateCreated = DateTime.UtcNow,
                DateLastUpdate = null
            };

            //TODO Validar se não existe!

            developerRepository.Add(model);

            if (Commit())
            {
                bus.RaiseEvent(new DeveloperRegisteredEvent(model.Id, model.DescriptionPT, model.DescriptionEN, model.EntityState, model.DateCreated));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = developerRepository.GetById(request.Id);
            if (model == null)
            {
                bus.RaiseEvent(new DomainNotification(request.MessageType, "This Developer not found."));
                return Task.FromResult(false);
            }

            model.DescriptionEN = request.DescriptionEN;
            model.DescriptionPT = request.DescriptionPT;
            model.EntityState = request.EntityState;
            model.DateLastUpdate = DateTime.UtcNow;
            model.HasChanges = true;
            developerRepository.Update(model);

            if (Commit())
            {
                bus.RaiseEvent(new DeveloperUpdatedEvent(model.Id, model.DescriptionPT, model.DescriptionEN, model.EntityState, model.DateCreated));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveDeveloperCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = developerRepository.GetById(request.Id);
            if (model == null)
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            model.EntityState = EntityStateOptions.Deleted;
            model.DateLastUpdate = DateTime.UtcNow;
            model.HasChanges = true;

            developerRepository.Update(model);

            if (Commit())
            {
                bus.RaiseEvent(new DeveloperRemovedEvent(model.Id));
            }
            return Task.FromResult(true);
        }
    }
}
