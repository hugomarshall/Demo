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

namespace DemoCore.Domain.CommandHandlers
{
    public class WorkAvailabilityCommandHandler : CommandHandler,
        IRequestHandler<RegisterQuestionCommand, bool>,
        IRequestHandler<UpdateQuestionCommand, bool>
    {
        private readonly IWorkAvailabilityRepository waRepository;
        private readonly IMediatorHandler bus;

        public WorkAvailabilityCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications
            , IWorkAvailabilityRepository waRepository) : base(uow, bus, notifications)
        {
            this.waRepository = waRepository;
            this.bus = bus;
        }

        public Task<bool> Handle(RegisterQuestionCommand request, CancellationToken cancellationToken)
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
                EntityState = request.EntityState,
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

        public Task<bool> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
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
    }
}
