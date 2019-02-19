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
    public class WorkAvailabilityCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewWorkAvailabilityCommand, bool>,
        IRequestHandler<UpdateWorkAvailabilityCommand, bool>,
        IRequestHandler<RemoveWorkAvailabilityCommand, bool>
    {
        private readonly IWorkAvailabilityRepository waRepository;
        private readonly IMediatorHandler bus;

        public WorkAvailabilityCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications
            , IWorkAvailabilityRepository waRepository) : base(uow, bus, notifications)
        {
            this.waRepository = waRepository;
            this.bus = bus;
        }

        public Task<bool> Handle(RegisterNewWorkAvailabilityCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = new WorkAvailability()
            {
                DescriptionEN = request.DescriptionEN,
                DescriptionPT = request.DescriptionPT,
                EntityState = EntityStateOptions.Active,
                DateCreated = DateTime.UtcNow,
                DateLastUpdate = null
            };

            //TODO Validar se não existe!

            waRepository.Add(model);

            if (Commit())
            {
                bus.RaiseEvent(new WorkAvailabilityRegisteredEvent(model.Id, model.DescriptionPT, model.DescriptionEN, model.EntityState, model.DateCreated));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateWorkAvailabilityCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = new WorkAvailability(request.Id)
            {
                DescriptionEN = request.DescriptionEN,
                DescriptionPT = request.DescriptionPT,
                EntityState = request.EntityState,
                DateLastUpdate = DateTime.UtcNow,
                HasChanges = true
            };
            waRepository.Update(model);

            if (Commit())
            {
                bus.RaiseEvent(new WorkAvailabilityUpdatedEvent(model.Id, model.DescriptionPT, model.DescriptionEN, model.EntityState, model.DateCreated));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveWorkAvailabilityCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = waRepository.GetById(request.Id);
            if (model == null)
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            model.EntityState = EntityStateOptions.Deleted;
            model.DateLastUpdate = DateTime.UtcNow;
            model.HasChanges = true;

            waRepository.Update(model);

            if (Commit())
            {
                bus.RaiseEvent(new WorkAvailabilityRemovedEvent(model.Id));
            }
            return Task.FromResult(true);
        }
    }
}
