using DemoCore.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCore.Domain.Models
{
    [Table("Knowledge", Schema = "DemoCoreData")]
    public class Knowledge: Entity
    {
        public Knowledge(): this(0)
        {
            IsNew = true;
            DateCreated = DateTime.UtcNow;
        }
        public Knowledge(int id)
        {
            Id = id;
            if (id != 0)
            {
                HasChanges = true;
                DateLastUpdate = DateTime.UtcNow;
                DateCreated = this.DateCreated;
            };
        }
        public int Id { get; private set; }
        public int PeopleId { get; set; }
        public virtual People People { get; set; }
        public virtual List<KnowledgeDesigner> KnowledgeDesigner { get; set; }
        public virtual List<KnowledgeDeveloper> KnowledgeDeveloper { get; set; }
        public string Other { get; set; }
        public string UrlLinkCRUD { get; set; }

        public override bool Validate()
        {
            //TODO Implement Validate
            return true;

        }
    }
}
