using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoCore.Domain.Models
{
    [Table("KnowledgeDesigner", Schema = "DemoCoreData")]
    public class KnowledgeDesigner
    {
        public int KnowledgeId { get; set; }
        public virtual Knowledge Knowledge { get; set; }
        public int DesignerId { get; set; }
        public virtual Designer Designer { get; set; }
        public int Value { get; set; }
    }
}
