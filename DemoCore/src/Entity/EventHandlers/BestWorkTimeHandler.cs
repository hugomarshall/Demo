using DemoCore.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCore.Domain.EventHandlers
{
    public class BestWorkTimeHandler : INotificationHandler<BestWorkTimeRegisteredEvent>,
                                    INotificationHandler<BestWorkTimeUpdatedEvent>,
                                    INotificationHandler<BestWorkTimeRemovedEvent>
    {
        public Task Handle(BestWorkTimeRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(BestWorkTimeUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(BestWorkTimeRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
