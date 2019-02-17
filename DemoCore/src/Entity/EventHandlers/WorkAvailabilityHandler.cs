using DemoCore.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCore.Domain.EventHandlers
{
    public class WorkAvailabilityHandler : INotificationHandler<WorkAvailabilityRegisteredEvent>,
                        INotificationHandler<WorkAvailabilityUpdatedEvent>,
                        INotificationHandler<WorkAvailabilityRemovedEvent>
    {
        public Task Handle(WorkAvailabilityRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(WorkAvailabilityUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(WorkAvailabilityRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
