using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Application.ViewModels
{
    public class KnowledgeDeveloperVM
    {
        public int Id { get; private set; }
        public int KnowledgeId { get; set; }
        public KnowledgeVM Knowledge { get; set; }
        public int DeveloperId { get; set; }
        public DeveloperVM Developer { get; set; }
        public int Value { get; set; }
    }
}
