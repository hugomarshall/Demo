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
    public class DesignerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewDesignerCommand, bool>,
        IRequestHandler<UpdateDesignerCommand, bool>
    {
        private readonly IDesignerRepository designerRepository;
        private readonly IMediatorHandler bus;

        public DesignerCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications
            ,IDesignerRepository designerRepository) : base(uow, bus, notifications)
        {
            this.designerRepository = designerRepository;
            this.bus = bus;
        }

        public Task<bool> Handle(RegisterNewDesignerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = new Designer()
            {
                DescriptionEN = request.DescriptionEN,
                DescriptionPT = request.DescriptionPT,
                EntityState = request.EntityState,
                DateCreated = DateTime.UtcNow,
                DateLastUpdate = null
            };

            //TODO Validar se não existe!

            designerRepository.Add(model);

            if (Commit())
            {
                bus.RaiseEvent(new DesignerRegisteredEvent(model.Id, model.DescriptionPT, model.DescriptionEN, model.EntityState, model.DateCreated));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateDesignerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = new Designer(request.Id)
            {
                DescriptionEN = request.DescriptionEN,
                DescriptionPT = request.DescriptionPT,
                EntityState = request.EntityState,
                DateLastUpdate = DateTime.UtcNow,
                HasChanges = true
            };
            designerRepository.Update(model);

            if (Commit())
            {
                bus.RaiseEvent(new DesignerUpdatedEvent(model.Id, model.DescriptionPT, model.DescriptionEN, model.EntityState, model.DateCreated));
            }
            return Task.FromResult(true);
        }
    }
}
