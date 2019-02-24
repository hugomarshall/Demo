using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCore.Domain.Models
{
    [Table("OccupationBestWorkTime", Schema = "DemoCoreData")]
    public class OccupationBestWorkTime
    {
        public int BestWorkTimeId { get; set; }
        public virtual BestWorkTime BestWorkTime { get; set; }
        public int OccupationId { get; set; }
        public virtual Occupation Occupation { get; set; }
    }
}
