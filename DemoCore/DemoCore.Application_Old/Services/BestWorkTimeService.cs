using AutoMapper;
using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace DemoCore.Application.Services
{
    public class BestWorkTimeService : IBestWorkTimeService
    {
        public BestWorkTimeService(IMapper mapper, IBestWorkTimeRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BestWorkTimeVM> GetAll()
        {
            throw new NotImplementedException();
        }

        public BestWorkTimeVM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Register(BestWorkTimeVM bestWorkVM)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BestWorkTimeVM bestWorkVM)
        {
            throw new NotImplementedException();
        }
    }
}
