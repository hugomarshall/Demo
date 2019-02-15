using AutoMapper;
using AutoMapper.QueryableExtensions;
using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Commands;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Interfaces;
using DemoCore.Infra.Data.Repositories.EventSourcing;
using System;
using System.Collections.Generic;

namespace DemoCore.Application.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IMapper mapper;
        private readonly IPeopleRepository peopleRepository;
        private readonly IMediatorHandler bus;
        private readonly IEventStoreRepository eventStoreRepository;

        public PeopleService(IMapper mapper, IPeopleRepository peopleRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            this.mapper = mapper;
            this.peopleRepository = peopleRepository;
            this.bus = bus;
            this.eventStoreRepository = eventStoreRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<PeopleVM> GetAll()
        {
            return peopleRepository.GetAll().ProjectTo<PeopleVM>();
        }

        public PeopleVM GetById(int id)
        {
            return mapper.Map<PeopleVM>(peopleRepository.GetById(id));
        }

        public void Register(PeopleVM peopleVM)
        {
            var registerCommand = mapper.Map<RegisterNewPeopleCommand>(peopleVM);
            bus.SendCommand(registerCommand);
        }

        public void Remove(int id)
        {
            //var removeCommand = new RemoveBestWorkTimeCommand(id);
            //bus.SendCommand(removeCommand);
        }

        public void Update(PeopleVM peopleVM)
        {
            var updateCommand = mapper.Map<UpdatePeopleCommand>(peopleVM);
            bus.SendCommand(updateCommand);
        }
    }
}
