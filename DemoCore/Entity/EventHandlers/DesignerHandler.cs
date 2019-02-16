using DemoCore.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCore.Domain.EventHandlers
{
    public class DesignerHandler : INotificationHandler<DesignerRegisteredEvent>,
                    INotificationHandler<DesignerUpdatedEvent>,
                    INotificationHandler<DesignerRemovedEvent>
    {
        public Task Handle(DesignerRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DesignerUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DesignerRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
