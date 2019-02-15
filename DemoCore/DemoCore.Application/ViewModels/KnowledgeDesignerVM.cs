using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Application.ViewModels
{
    public class KnowledgeDesignerVM
    {
        public int Id { get; private set; }
        public int KnowledgeId { get; set; }
        public KnowledgeVM Knowledge { get; set; }
        public int DesignerId { get; set; }
        public DesignerVM Designer { get; set; }
        public int Value { get; set; }
    }
}
