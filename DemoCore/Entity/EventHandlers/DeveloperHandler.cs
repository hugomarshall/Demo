using DemoCore.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCore.Domain.EventHandlers
{
    public class DeveloperHandler : INotificationHandler<DeveloperRegisteredEvent>,
                    INotificationHandler<DeveloperUpdatedEvent>,
                    INotificationHandler<DeveloperRemovedEvent>
    {
        public Task Handle(DeveloperRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DeveloperUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DeveloperRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
