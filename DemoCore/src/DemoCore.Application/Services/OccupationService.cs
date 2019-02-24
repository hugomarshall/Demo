using AutoMapper;
using AutoMapper.QueryableExtensions;
using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Commands;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Repositories.EventSourcing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoCore.Application.Services
{
    public class OccupationService : IOccupationService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler bus;
        private readonly IEventStoreRepository eventStoreRepository;
        private readonly IOccupationRepository occupationRepository;
        private readonly IOccupationBestWorkTimeRepository occupationBestWorkTimeRepository;
        private readonly IBestWorkTimeRepository bestWorkTimeRepository;
        private readonly IOccupationWorkAvailabilityRepository occupationWorkAvailRepository;

        public OccupationService(IMapper mapper, IOccupationRepository occupationRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository,
            IOccupationBestWorkTimeRepository occupationBestWorkTimeRepository, IBestWorkTimeRepository bestWorkTimeRepository,
            IOccupationWorkAvailabilityRepository occupationWorkAvailRepository)
        {
            this.mapper = mapper;
            this.bus = bus;
            this.eventStoreRepository = eventStoreRepository;
            this.occupationRepository = occupationRepository;
            this.occupationBestWorkTimeRepository = occupationBestWorkTimeRepository;
            this.bestWorkTimeRepository = bestWorkTimeRepository;
            this.occupationWorkAvailRepository = occupationWorkAvailRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<OccupationVM> GetAll()
        {
            return occupationRepository.GetAll().ProjectTo<OccupationVM>(mapper.ConfigurationProvider);
        }

        public OccupationVM GetById(int id)
        {
            return mapper.Map<OccupationVM>(occupationRepository.GetById(id));
        }

        public void Register(OccupationVM request)
        {
            var model = mapper.Map<Occupation>(request);
            var registerCommand = mapper.Map<RegisterNewOccupationCommand>(model);
            bus.SendCommand(registerCommand);
        }

        public void Remove(int id)
        {
            //var removeCommand = new RemoveOccupationCommand(id);
            //bus.SendCommand(removeCommand);
        }

        public void Update(OccupationVM bestWorkVM)
        {
            //var updateCommand = mapper.Map<UpdateBestWorkTimeCommand>(bestWorkVM);
            //bus.SendCommand(updateCommand);
        }

        public OccupationVM GetOccupationIncludeChilds(int id)
        {
            return mapper.Map<OccupationVM>(occupationRepository.Get(x => x.Id.Equals(id)).Include(x => x.BestWorkTimes).Include(x => x.WorkAvailabilities));
        }

        public void UpdateOccupationBestWorkTime(string[] selectedBestWorkTime, OccupationVM occupationToUpdate)
        {
            if(occupationToUpdate.BestWorkTimes == null) occupationToUpdate.BestWorkTimes = new List<OccupationBestWorkTimeVM>();
            
            var all = bestWorkTimeRepository.GetAll();
            var selectedBestWorkTimeHS = new HashSet<string>(selectedBestWorkTime);
            var occupationBestWorkTime = new HashSet<int>(occupationToUpdate.BestWorkTimes.Select(c => c.BestWorkTime.Id));
            occupationBestWorkTimeRepository.RemoveAll(occupationToUpdate.Id);
            foreach (var bestWorkTime in all)
            {
                if (selectedBestWorkTimeHS.Contains(bestWorkTime.Id.ToString()))
                {
                    if (!occupationBestWorkTime.Contains(bestWorkTime.Id))
                    {
                        occupationToUpdate.BestWorkTimes.Add(new OccupationBestWorkTimeVM { OccupationId = occupationToUpdate.Id, BestWorkTimeId = bestWorkTime.Id });
                    }
                }
                else
                {

                    if (occupationBestWorkTime.Contains(bestWorkTime.Id))
                    {
                        var bestWorkTimeToRemove = occupationToUpdate.BestWorkTimes.SingleOrDefault(i => i.BestWorkTimeId == bestWorkTime.Id);
                        occupationBestWorkTimeRepository.Remove(mapper.Map<OccupationBestWorkTime>(bestWorkTimeToRemove));
                    }
                }
            }
        }

        public void UpdateOccupationWorkAvailability(string[] selectedWorkAvailability, OccupationVM occupationToUpdate)
        {
            if (occupationToUpdate.WorkAvailabilities == null) occupationToUpdate.WorkAvailabilities = new List<OccupationWorkAvailabilityVM>();

            var all = bestWorkTimeRepository.GetAll();
            var selectedWAHS = new HashSet<string>(selectedWorkAvailability);
            var occupationWA = new HashSet<int>(occupationToUpdate.WorkAvailabilities.Select(c => c.WorkAvailability.Id));
            
            occupationWorkAvailRepository.RemoveAll(occupationToUpdate.Id);
            foreach (var workAval in all)
            {
                
                if (selectedWAHS.Contains(workAval.Id.ToString()))
                {
                    if (!occupationWA.Contains(workAval.Id))
                    {
                        occupationToUpdate.WorkAvailabilities.Add(new OccupationWorkAvailabilityVM { OccupationId = occupationToUpdate.Id, WorkAvailabilityId = workAval.Id });
                    }
                }
                else
                {
                    if (occupationWA.Contains(workAval.Id))
                    {
                        var workAvalToRemove = occupationToUpdate.WorkAvailabilities.SingleOrDefault(i => i.WorkAvailabilityId == workAval.Id);
                        occupationWorkAvailRepository.Remove(mapper.Map<OccupationWorkAvailability>(workAvalToRemove));
                    }
                }
            }
        }
    }
}
