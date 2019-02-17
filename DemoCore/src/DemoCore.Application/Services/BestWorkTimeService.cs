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
    public class BestWorkTimeService : IBestWorkTimeService
    {
        private readonly IMapper mapper;
        private readonly IBestWorkTimeRepository bestWorkTimeRepository;
        private readonly IMediatorHandler bus;
        private readonly IEventStoreRepository eventStoreRepository;

        public BestWorkTimeService(IMapper mapper, IBestWorkTimeRepository bestWorkTimeRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            this.mapper = mapper;
            this.bestWorkTimeRepository = bestWorkTimeRepository;
            this.bus = bus;
            this.eventStoreRepository = eventStoreRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<BestWorkTimeVM> GetAll()
        {
            return bestWorkTimeRepository.GetAll().ProjectTo<BestWorkTimeVM>(mapper.ConfigurationProvider);
        }

        public BestWorkTimeVM GetById(int id)
        {
            return mapper.Map<BestWorkTimeVM>(bestWorkTimeRepository.GetById(id));
        }

        public void Register(BestWorkTimeVM request)
        {
            var registerCommand = mapper.Map<RegisterNewBestWorkTimeCommand>(request);
            bus.SendCommand(registerCommand);
        }

        public void Remove(int id)
        {
            //var removeCommand = new RemoveBestWorkTimeCommand(id);
            //bus.SendCommand(removeCommand);
        }

        public void Update(BestWorkTimeVM bestWorkVM)
        {
            var updateCommand = mapper.Map<UpdateBestWorkTimeCommand>(bestWorkVM);
            bus.SendCommand(updateCommand);
        }
    }
}
