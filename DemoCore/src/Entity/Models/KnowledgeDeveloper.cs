using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoCore.Domain.Models
{
    [Table("KnowledgeDeveloper", Schema = "DemoCoreData")]
    public class KnowledgeDeveloper
    {
        public int KnowledgeId { get; set; }
        public virtual Knowledge Knowledge { get; set; }
        public int DeveloperId { get; set; }
        public virtual Developer Developer { get; set; }
        public int Value { get; set; }
    }
}
