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
using System.Linq;

namespace DemoCore.Application.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IMapper mapper;
        private readonly IDeveloperRepository developerRepository;
        private readonly IMediatorHandler bus;
        private readonly IEventStoreRepository eventStoreRepository;
        public DeveloperService(IMapper mapper, IDeveloperRepository developerRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            this.mapper = mapper;
            this.developerRepository = developerRepository;
            this.bus = bus;
            this.eventStoreRepository = eventStoreRepository;

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<DeveloperVM> GetAll()
        {
            return developerRepository.GetAll().ProjectTo<DeveloperVM>(mapper.ConfigurationProvider).ToList();
        }

        public DeveloperVM GetById(int id)
        {
            return mapper.Map<DeveloperVM>(developerRepository.GetById(id));
        }

        public void Register(DeveloperVM developerVM)
        {
            var registerCommand = mapper.Map<RegisterNewDeveloperCommand>(developerVM);
            bus.SendCommand(registerCommand);
        }

        public void Remove(int id)
        {
            //var removeCommand = new RemoveQuestionCommand(id);
            //bus.SendCommand(removeCommand);
        }

        public void Update(DeveloperVM request)
        {
            var updateCommand = mapper.Map<UpdateDeveloperCommand>(request);
            bus.SendCommand(updateCommand);
        }
    }
}
