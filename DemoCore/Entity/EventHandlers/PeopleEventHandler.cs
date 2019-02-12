using DemoCore.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCore.Domain.EventHandlers
{
    public class PeopleEventHandler : INotificationHandler<PeopleRegisteredEvent>,
                                    INotificationHandler<PeopleUpdatedEvent>,
                                    INotificationHandler<PeopleRemovedEvent>
    {
        public Task Handle(PeopleUpdatedEvent notification, CancellationToken cancellationToken)
        {
            //Send notification e-mail
            return Task.CompletedTask;
        }

        public Task Handle(PeopleRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // send grettings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(PeopleRemovedEvent notification, CancellationToken cancellationToken)
        {
            // send grettings e-mail

            return Task.CompletedTask;
        }
    }
}
