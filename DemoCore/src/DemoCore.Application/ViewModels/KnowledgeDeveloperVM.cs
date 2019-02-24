using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Application.ViewModels
{
    public class KnowledgeDeveloperVM
    {
        public KnowledgeDeveloperVM()
        {
            //Knowledge = new KnowledgeVM();
            //Developer = new DeveloperVM();
        }
        public int KnowledgeId { get; set; }
        public virtual KnowledgeVM Knowledge { get; set; }
        public int DeveloperId { get; set; }
        public virtual DeveloperVM Developer { get; set; }
        public int Value { get; set; }
    }
}
