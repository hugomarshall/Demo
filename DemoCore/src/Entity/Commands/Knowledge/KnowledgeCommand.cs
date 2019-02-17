using DemoCore.Domain.Core.Commands;
using DemoCore.Domain.Models;
using System;
using System.Collections.Generic;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public abstract class KnowledgeCommand: Command
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
        public List<KnowledgeDesigner> KnowledgeDesigner { get; set; }
        public List<KnowledgeDeveloper> KnowledgeDeveloper { get; set; }
        public string Other { get; set; }
        public string UrlLinkCRUD { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public bool HasChanges { get; set; }
        public bool IsNew { get; protected set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastUpdate { get; set; }
    }
}
