using AutoMapper;
using AutoMapper.QueryableExtensions;
using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Commands;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Repositories.EventSourcing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return peopleRepository.GetAll().ProjectTo<PeopleVM>(mapper.ConfigurationProvider);
        }

        public async Task<PeopleVM> GetByEmailAsync(string email)
        {
            try
            {
                var people = await peopleRepository.GetByEmail(email);
                var model = mapper.Map<PeopleVM>(people);
                return model;
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            
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
            var model = mapper.Map<People>(peopleVM);
            var updateCommand = mapper.Map<UpdatePeopleCommand>(model);
            bus.SendCommand(updateCommand);
        }
    }
}
