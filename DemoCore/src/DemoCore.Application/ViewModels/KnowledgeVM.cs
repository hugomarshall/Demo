using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Application.ViewModels
{
    [BindProperties]
    public class KnowledgeVM
    {
        public KnowledgeVM()
        {
            //People = new PeopleVM();
            //KnowledgeDesigner = new List<KnowledgeDesignerVM>();
            //KnowledgeDeveloper = new List<KnowledgeDeveloperVM>();
        }
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public PeopleVM People { get; set; }
        public List<KnowledgeDesignerVM> KnowledgeDesigner { get; set; }
        public List<KnowledgeDeveloperVM> KnowledgeDeveloper { get; set; }
        public string Other { get; set; }
        public string UrlLinkCRUD { get; set; }
        public EntityStateOptions EntityState { get; set; }
    }
}
