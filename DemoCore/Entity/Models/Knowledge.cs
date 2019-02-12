using DemoCore.Domain.Core.Models;
using System.Collections.Generic;

namespace DemoCore.Domain.Models
{
    public class Knowledge: Entity
    {
        public Knowledge(): this(0)
        {
            IsNew = true;
        }
        public Knowledge(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
        public List<KnowledgeDesigner> KnowledgeDesigner { get; set; }
        public List<KnowledgeDeveloper> KnowledgeDeveloper { get; set; }
        public string Other { get; set; }
        public string UrlLinkCRUD { get; set; }

        public override bool Validate()
        {
            //TODO Implement Validate
            return true;

        }
    }
}
