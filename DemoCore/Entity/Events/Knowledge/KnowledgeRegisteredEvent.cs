using DemoCore.Domain.Core.Events;
using DemoCore.Domain.Models;
using System;
using System.Collections.Generic;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Events
{
    public class KnowledgeRegisteredEvent: Event
    {
        public KnowledgeRegisteredEvent(int id, int peopleId, People people, List<KnowledgeDesigner> knowledgeDesigner, List<KnowledgeDeveloper> knowledgeDeveloper, string other, string urlLink, EntityStateOptions entityState, DateTime dateCreated)
        {
            Id = id;
            PeopleId = peopleId;
            People = people;
            KnowledgeDesigner = knowledgeDesigner;
            KnowledgeDeveloper = knowledgeDeveloper;
            Other = other;
            UrlLinkCRUD = urlLink;
            EntityState = entityState;
            DateCreated = dateCreated;
        }

        public int Id { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
        public List<KnowledgeDesigner> KnowledgeDesigner { get; set; }
        public List<KnowledgeDeveloper> KnowledgeDeveloper { get; set; }
        public string Other { get; set; }
        public string UrlLinkCRUD { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public DateTime DateCreated { get; set; }
        
    }
}
