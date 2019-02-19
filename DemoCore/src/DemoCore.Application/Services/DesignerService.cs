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
    public class DesignerService : IDesignerService
    {
        private readonly IMapper mapper;
        private readonly IDesignerRepository designerRepository;
        private readonly IMediatorHandler bus;
        private readonly IEventStoreRepository eventStoreRepository;

        public DesignerService(IMapper mapper, IDesignerRepository designerRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository )
        {
            this.mapper = mapper;
            this.designerRepository = designerRepository;
            this.bus = bus;
            this.eventStoreRepository = eventStoreRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<DesignerVM> GetAll()
        {
            return designerRepository.GetAll().ProjectTo<DesignerVM>(mapper.ConfigurationProvider);
        }

        public DesignerVM GetById(int id)
        {
            return mapper.Map<DesignerVM>(designerRepository.GetById(id));
        }

        public void Register(DesignerVM request)
        {
            var registerCommand = mapper.Map<RegisterNewDesignerCommand>(request);
            bus.SendCommand(registerCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveDesignerCommand(id);
            bus.SendCommand(removeCommand);
        }

        public void Update(DesignerVM request)
        {
            var updateCommand = mapper.Map<UpdateDesignerCommand>(request);
            bus.SendCommand(updateCommand);
        }
    }
}
