using DemoCore.Domain.Core.Events;
using DemoCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Events
{
    public class PeopleUpdatedEvent: Event
    {
        public PeopleUpdatedEvent(int id, string name, string email, string skype, string celular, string linkedIn, string cidade, string estado, string portfolio, bool isDeveloper, bool isDesigner, int occupationId, Occupation occupation, int knowledgeId, Knowledge knowledge)
        {
            Id = id;
            Name = name;
            Email = email;
            Skype = skype;
            Celular = celular;
            LinkedIn = linkedIn;
            Cidade = cidade;
            Estado = estado;
            Portfolio = portfolio;
            OccupationId = occupationId;
            Occupation = occupation;
            KnowledgeId = knowledgeId;
            Knowledge = knowledge;
            DateLastUpdate = DateTime.Now;
            EntityState = EntityStateOptions.Active;
            HasChanges = true;
            IsNew = false;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Celular { get; set; }
        public string LinkedIn { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Portfolio { get; set; }
        public bool IsDeveloper { get; set; }
        public bool IsDesigner { get; set; }
        public int OccupationId { get; set; }
        public Occupation Occupation { get; set; }
        public int KnowledgeId { get; set; }
        public Knowledge Knowledge { get; set; }

        public DateTime? DateLastUpdate { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public bool HasChanges { get; set; }
        public bool IsNew { get; set; }
    }
}
