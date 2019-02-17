using DemoCore.Domain.Core.Events;
using DemoCore.Domain.Models;
using System;
using System.Collections.Generic;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Events
{
    public class KnowledgeUpdatedEvent: Event
    {
        public KnowledgeUpdatedEvent(int id, int peopleId, People people, List<KnowledgeDesigner> knowledgeDesigner, List<KnowledgeDeveloper> knowledgeDeveloper, string other, string urlLink, EntityStateOptions entityState, DateTime dateUpdated)
        {
            Id = id;
            PeopleId = peopleId;
            People = people;
            KnowledgeDesigner = knowledgeDesigner;
            KnowledgeDeveloper = knowledgeDeveloper;
            Other = other;
            UrlLinkCRUD = urlLink;
            EntityState = entityState;
            DateLastUpdate = dateUpdated;
        }

        public int Id { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
        public List<KnowledgeDesigner> KnowledgeDesigner { get; set; }
        public List<KnowledgeDeveloper> KnowledgeDeveloper { get; set; }
        public string Other { get; set; }
        public string UrlLinkCRUD { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public DateTime DateLastUpdate { get; set; }

    }
}
