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
    public class KnowledgeCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewKnowledgeCommand, bool>,
        IRequestHandler<UpdateKnowledgeCommand, bool>
    {
        private readonly IUnitOfWork uow;
        private readonly IMediatorHandler bus;
        private readonly IKnowledgeRepository knowledgeRepository;

        public KnowledgeCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications,
            IKnowledgeRepository knowledgeRepository) : base(uow, bus, notifications)
        {
            this.uow = uow;
            this.bus = bus;
            this.knowledgeRepository = knowledgeRepository;
        }

        public Task<bool> Handle(RegisterNewKnowledgeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = new Knowledge()
            {
                PeopleId = request.PeopleId,
                EntityState = EntityStateOptions.Active,
                KnowledgeDesigner = request.KnowledgeDesigner,
                KnowledgeDeveloper = request.KnowledgeDeveloper,
                UrlLinkCRUD = request.UrlLinkCRUD,
                Other = request.Other
            };

            //TODO Validar se não existe!

            knowledgeRepository.Add(model);

            if (Commit())
            {
                bus.RaiseEvent(new KnowledgeRegisteredEvent(model.Id, "user"));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateKnowledgeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
