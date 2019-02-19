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
    public class BestWorkTimeCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewBestWorkTimeCommand, bool>,
        IRequestHandler<UpdateBestWorkTimeCommand, bool>,
        IRequestHandler<RemoveBestWorkTimeCommand, bool>
    {
        private readonly IBestWorkTimeRepository bwtRepository;
        private readonly IMediatorHandler bus;

        public BestWorkTimeCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications
            ,IBestWorkTimeRepository bwtRepository) : base(uow, bus, notifications)
        {
            this.bwtRepository = bwtRepository;
            this.bus = bus;
        }

        public Task<bool> Handle(RegisterNewBestWorkTimeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = new BestWorkTime()
            {
                DescriptionEN = request.DescriptionEN,
                DescriptionPT = request.DescriptionPT,
                EntityState = EntityStateOptions.Active,
                DateCreated = DateTime.UtcNow,
                DateLastUpdate = null
            };

            //TODO Validar se não existe!

            bwtRepository.Add(model);

            if(Commit())
            {
                bus.RaiseEvent(new BestWorkTimeRegisteredEvent(model.Id, model.DescriptionPT, model.DescriptionEN));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateBestWorkTimeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = new BestWorkTime(request.Id)
            {
                DescriptionEN = request.DescriptionEN,
                DescriptionPT = request.DescriptionPT,
                EntityState = EntityStateOptions.Active,
                DateLastUpdate = DateTime.UtcNow,
                HasChanges = true
            };
            bwtRepository.Update(model);

            if (Commit())
            {
                bus.RaiseEvent(new BestWorkTimeUpdatedEvent(model.Id, model.DescriptionPT, model.DescriptionEN));
            }
            return Task.FromResult(true);
        }

        public void Dispose()
        {
            bwtRepository.Dispose();
        }

        public Task<bool> Handle(RemoveBestWorkTimeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = bwtRepository.GetById(request.Id);
            if (model == null)
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            model.EntityState = EntityStateOptions.Deleted;
            model.DateLastUpdate = DateTime.UtcNow;
            model.HasChanges = true;
            
            bwtRepository.Update(model);

            if (Commit())
            {
                bus.RaiseEvent(new BestWorkTimeRemovedEvent(model.Id));
            }
            return Task.FromResult(true);
        }
    }
}
