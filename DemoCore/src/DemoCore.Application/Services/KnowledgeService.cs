using AutoMapper;
using AutoMapper.QueryableExtensions;
using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Commands;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Core.Commands;
using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Repositories.EventSourcing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoCore.Application.Services
{
    public class KnowledgeService : IKnowledgeService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler bus;
        private readonly IEventStoreRepository eventStoreRepository;
        private readonly IKnowledgeRepository knowledgeRepository;
        private readonly IKnowledgeDeveloperRepository knowledgeDeveloperRepository;
        private readonly IKnowledgeDesignerRepository knowledgeDesignerRepository;
        private readonly IDeveloperRepository developerRepository;
        private readonly IDesignerRepository designerRepository;

        public KnowledgeService(IMapper mapper, IMediatorHandler bus, IEventStoreRepository eventStoreRepository,
            IKnowledgeRepository knowledgeRepository, IKnowledgeDeveloperRepository knowledgeDeveloperRepository,
            IKnowledgeDesignerRepository knowledgeDesignerRepository, IDeveloperRepository developerRepository,
            IDesignerRepository designerRepository)
        {
            this.mapper = mapper;
            this.bus = bus;
            this.eventStoreRepository = eventStoreRepository;
            this.knowledgeRepository = knowledgeRepository;
            this.knowledgeDeveloperRepository = knowledgeDeveloperRepository;
            this.knowledgeDesignerRepository = knowledgeDesignerRepository;
            this.developerRepository = developerRepository;
            this.designerRepository = designerRepository;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<KnowledgeVM> GetAll()
        {
            return knowledgeRepository.GetAll().ProjectTo<KnowledgeVM>(mapper.ConfigurationProvider);
        }

        public KnowledgeVM GetById(int id)
        {
            return mapper.Map<KnowledgeVM>(knowledgeRepository.GetById(id));
        }

        public KnowledgeVM GetKnowledgeIncludeChilds(int id)
        {
            return mapper.Map<KnowledgeVM>(knowledgeRepository.Get(x => x.Id.Equals(id)).Include(x => x.KnowledgeDesigner).Include(x => x.KnowledgeDeveloper));
        }

        public void Register(KnowledgeVM request)
        {
            if(request.Id == 0)
            {
                var command = mapper.Map<RegisterNewKnowledgeCommand>(request);
                bus.SendCommand(command);
            }
            else
            {
                var command = mapper.Map<UpdateKnowledgeCommand>(request);
                bus.SendCommand(command);

            }
        }

        public void Remove(int id)
        {
            //var removeCommand = new RemoveKnowledgeCommand(id);
            //bus.SendCommand(removeCommand);
        }

        public void Update(KnowledgeVM request)
        {
            var updateCommand = mapper.Map<UpdateKnowledgeCommand>(request);
            bus.SendCommand(updateCommand);
        }

        public void UpdateKnowledgeDesigner(string[] selectedDesigner, KnowledgeVM knowledgeToUpdate)
        {
            if (knowledgeToUpdate.KnowledgeDesigner == null) knowledgeToUpdate.KnowledgeDesigner = new List<KnowledgeDesignerVM>();

            var all = designerRepository.GetAll();
            var selectedDesignerHS = new HashSet<string>(selectedDesigner);
            var knowledgeDesigner = new HashSet<int>(knowledgeToUpdate.KnowledgeDesigner.Select(c => c.Designer.Id));
            knowledgeDesignerRepository.RemoveAll(knowledgeToUpdate.Id);
            foreach (var designer in all)
            {
                if (selectedDesignerHS.Contains(designer.Id.ToString()))
                {
                    if (!knowledgeDesigner.Contains(designer.Id))
                    {
                        knowledgeToUpdate.KnowledgeDesigner.Add(new KnowledgeDesignerVM { KnowledgeId = knowledgeToUpdate.Id, DesignerId = designer.Id });
                    }
                }
                else
                {

                    if (knowledgeDesigner.Contains(designer.Id))
                    {
                        var knowledgeToRemove = knowledgeToUpdate.KnowledgeDesigner.SingleOrDefault(i => i.DesignerId == designer.Id);
                        knowledgeDesignerRepository.Remove(mapper.Map<KnowledgeDesigner>(knowledgeToRemove));
                    }
                }
            }
        }

        public void UpdateKnowledgeDeveloper(string[] selectedDeveloper, KnowledgeVM knowledgeToUpdate)
        {
            if (knowledgeToUpdate.KnowledgeDeveloper == null) knowledgeToUpdate.KnowledgeDeveloper = new List<KnowledgeDeveloperVM>();

            var all = developerRepository.GetAll();
            var selectedDeveloperHS = new HashSet<string>(selectedDeveloper);
            var knowledgeDeveloper = new HashSet<int>(knowledgeToUpdate.KnowledgeDeveloper.Select(c => c.Developer.Id));
            knowledgeDesignerRepository.RemoveAll(knowledgeToUpdate.Id);

            foreach (var developer in all)
            {
                if (selectedDeveloperHS.Contains(developer.Id.ToString()))
                {
                    if (!knowledgeDeveloper.Contains(developer.Id))
                    {
                        knowledgeToUpdate.KnowledgeDeveloper.Add(new KnowledgeDeveloperVM { KnowledgeId = knowledgeToUpdate.Id, DeveloperId = developer.Id });
                    }
                }
                else
                {

                    if (knowledgeDeveloper.Contains(developer.Id))
                    {
                        var knowledgeToRemove = knowledgeToUpdate.KnowledgeDeveloper.SingleOrDefault(i => i.DeveloperId == developer.Id);
                        knowledgeDeveloperRepository.Remove(mapper.Map<KnowledgeDeveloper>(knowledgeToRemove));
                    }
                }
            }
        }
    }
}
