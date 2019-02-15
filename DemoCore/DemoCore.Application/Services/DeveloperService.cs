using AutoMapper;
using AutoMapper.QueryableExtensions;
using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Interfaces;
using DemoCore.Infra.Data.Repositories.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            throw new NotImplementedException();
        }

        public void Register(DeveloperVM developerVM)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DeveloperVM developerVM)
        {
            throw new NotImplementedException();
        }
    }
}
