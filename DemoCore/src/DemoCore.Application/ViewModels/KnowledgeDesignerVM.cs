using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Application.ViewModels
{
    public class KnowledgeDesignerVM
    {
        public KnowledgeDesignerVM()
        {
            //Knowledge = new KnowledgeVM();
            //Designer = new DesignerVM();
        }
        public int KnowledgeId { get; set; }
        public virtual KnowledgeVM Knowledge { get; set; }
        public int DesignerId { get; set; }
        public virtual DesignerVM Designer { get; set; }
        public int Value { get; set; }
    }
}
