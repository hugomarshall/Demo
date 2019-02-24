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
    public class OccupationCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewOccupationCommand, bool>,
        IRequestHandler<UpdateOccupationCommand, bool>
    {
        private readonly IUnitOfWork uow;
        private readonly IMediatorHandler bus;
        private readonly IOccupationRepository occupationRepository;

        public OccupationCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications
            ,IOccupationRepository occupationRepository) : base(uow, bus, notifications)
        {
            this.uow = uow;
            this.bus = bus;
            this.occupationRepository = occupationRepository;
        }

        public Task<bool> Handle(RegisterNewOccupationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var model = new Occupation()
            {
                PeopleId = request.PeopleId,
                //People = request.People,
                BestWorkTimes = request.BestWorkTimes,
                WorkAvailabilities = request.WorkAvailabilities
            };

            //TODO Validar se não existe!

            occupationRepository.Add(model);

            if (Commit())
            {
                bus.RaiseEvent(new OccupationRegisteredEvent(model.Id, model.PeopleId, model.People, model.WorkAvailabilities, model.BestWorkTimes, model.EntityState, model.DateCreated));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateOccupationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
