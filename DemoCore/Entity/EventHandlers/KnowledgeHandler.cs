using DemoCore.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCore.Domain.EventHandlers
{
    public class KnowledgeHandler : INotificationHandler<KnowledgeRegisteredEvent>,
                    INotificationHandler<KnowledgeUpdatedEvent>,
                    INotificationHandler<KnowledgeRemovedEvent>
    {
        public Task Handle(KnowledgeRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(KnowledgeUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(KnowledgeRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
