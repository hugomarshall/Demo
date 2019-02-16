using DemoCore.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCore.Domain.EventHandlers
{
    public class OccupationHandler : INotificationHandler<OccupationRegisteredEvent>,
                        INotificationHandler<OccupationUpdatedEvent>,
                        INotificationHandler<OccupationRemovedEvent>
    {
        public Task Handle(OccupationRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OccupationUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OccupationRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
