using AutoMapper;
using AutoMapper.QueryableExtensions;
using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Commands;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Interfaces;
using DemoCore.Infra.Data.Repositories.EventSourcing;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DemoCore.Application.Services
{
    public class BestWorkTimeService : IBestWorkTimeService
    {
        private readonly IMapper mapper;
        private readonly IBestWorkTimeRepository bestWorkTimeRepository;
        private readonly IOccupationBestWorkTimeRepository occupationBestWorkTimeRepository;
        private readonly IMediatorHandler bus;
        private readonly IEventStoreRepository eventStoreRepository;

        public BestWorkTimeService(IMapper mapper, IBestWorkTimeRepository bestWorkTimeRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository,
            IOccupationBestWorkTimeRepository occupationBestWorkTimeRepository)
        {
            this.mapper = mapper;
            this.bestWorkTimeRepository = bestWorkTimeRepository;
            this.bus = bus;
            this.eventStoreRepository = eventStoreRepository;
            this.occupationBestWorkTimeRepository = occupationBestWorkTimeRepository;
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
            var removeCommand = new RemoveBestWorkTimeCommand(id);
            bus.SendCommand(removeCommand);
        }

        public void Update(BestWorkTimeVM bestWorkVM)
        {
            var updateCommand = mapper.Map<UpdateBestWorkTimeCommand>(bestWorkVM);
            bus.SendCommand(updateCommand);
        }

        public IEnumerable<SelectedItems> GetSelectedBestWorkTime()
        {
            var bwt = bestWorkTimeRepository.GetAll().ProjectTo<BestWorkTimeVM>(mapper.ConfigurationProvider);
            var response = new Collection<SelectedItems>();
            foreach(var item in bwt)
            {
                response.Add(
                    new SelectedItems
                    {
                        Id = item.Id,
                        DescriptionEN = item.DescriptionEN,
                        DescriptionPT = item.DescriptionPT,
                        Assigned = false,
                    }
                );
            }
            return response;
        }
    }
}
