using DemoCore.Domain.Commands;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Core.Notifications;
using DemoCore.Domain.Events;
using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.CommandHandlers
{
    public class PeopleCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPeopleCommand, bool>,
        IRequestHandler<UpdatePeopleCommand, bool>,
        IRequestHandler<RemovePeopleCommand, bool>
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

        public Task<bool> Handle(RegisterNewPeopleCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var people = new People()
            {
                Name = request.Name,
                Email = request.Email,
                Skype = request.Skype,
                Phone = request.Phone,
                LinkedIn = request.LinkedIn,
                City = request.City,
                State = request.State,
                Portfolio = request.Portfolio,
                IsDesigner = request.IsDesigner,
                IsDeveloper = request.IsDeveloper,
                Occupation = request.Occupation,
                Knowledge = request.Knowledge,
                EntityState = EntityStateOptions.Active,
            };

            if (peopleRepository.GetByEmail(people.Email) != null)
            {
                bus.RaiseEvent(new DomainNotification(request.MessageType, "The people e-mail has already been taken."));
                return Task.FromResult(false);
            }

            peopleRepository.Add(people);

            if (Commit())
            {
                bus.RaiseEvent(new PeopleRegisteredEvent(people.Id, people.Name, people.Email, people.Skype, people.Phone, people.LinkedIn, people.IsDeveloper, people.IsDesigner));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePeopleCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var people = peopleRepository.Get(x => x.Email.Equals(request.Email), x=> x.Occupation, x => x.Knowledge).FirstOrDefault();

            if(people == null)
            {
                bus.RaiseEvent(new DomainNotification(request.MessageType, "People not found."));
                return Task.FromResult(false);
            }
            people.Name = request.Name;
            people.Email = request.Email;
            people.Skype = request.Skype;
            people.Phone = request.Phone;
            people.LinkedIn = request.LinkedIn;
            people.City = request.City;
            people.State = request.State;
            people.Portfolio = request.Portfolio;
            people.IsDesigner = request.IsDesigner;
            people.IsDeveloper = request.IsDeveloper;
            people.Occupation = request.Occupation;
            people.Knowledge = request.Knowledge;
            people.EntityState = request.EntityState;
            
            peopleRepository.Update(people);

            if (Commit())
            {
                bus.RaiseEvent(new PeopleUpdatedEvent(people.Id, people.Name, people.Email, people.Skype, people.Phone, people.LinkedIn, people.City, people.State, people.Portfolio, people.IsDeveloper, people.IsDesigner, null, null));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemovePeopleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
