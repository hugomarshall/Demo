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
    public class PeopleCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPeopleCommand>,
        IRequestHandler<UpdatePeopleCommand>,
        IRequestHandler<RemovePeopleCommand>
    {
        private readonly IPeopleRepository peopleRepository;
        private readonly IMediatorHandler bus;

        public PeopleCommandHandler(IPeopleRepository peopleRepository, 
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.peopleRepository = peopleRepository;
            this.bus = bus;


        }

        public Task<Unit> Handle(RegisterNewPeopleCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid())
            {
                NotifyValidationErrors(request);
                //return Unit.Value; //for async/await
                return Unit.Task; //for pure Task-based methods
            }

            var people = new People()
            {
                Name = request.Name,
                Email = request.Email,
                Skype = request.Skype,
                Phone = request.Celular,
                LinkedIn = request.LinkedIn,
                City = request.Cidade,
                State = request.Estado,
                Portfolio = request.Portfolio,
                IsDesigner = request.IsDesigner,
                IsDeveloper = request.IsDeveloper,
                Occupation = request.Occupation,
                Knowledge = request.Knowledge,
                DateCreated = DateTime.Now,
                DateLastUpdate = null,
                EntityState = EntityStateOptions.Active,
                HasChanges = false,
            };

            if (peopleRepository.GetByEmail(people.Email) != null)
            {
                bus.RaiseEvent(new DomainNotification(request.MessageType, "The people e-mail has already been taken."));
                //return Unit.Value; //for async/await
                return Unit.Task; //for pure Task-based methods
            }

            peopleRepository.Add(people);

            if (Commit())
            {
                bus.RaiseEvent(new PeopleRegisteredEvent(people.Id, people.Name, people.Email, people.Skype, people.Phone, people.LinkedIn, people.IsDeveloper, people.IsDesigner));
            }
            //return Unit.Value; //for async/await
            return Unit.Task; //for pure Task-based methods
        }

        public Task<Unit> Handle(UpdatePeopleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(RemovePeopleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
