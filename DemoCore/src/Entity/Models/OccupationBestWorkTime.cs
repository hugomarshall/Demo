using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCore.Domain.Models
{
    [Table("OccupationBestWorkTime", Schema = "DemoCoreData")]
    public class OccupationBestWorkTime
    {
        public OccupationBestWorkTime():this(0)
        {

        }
        public OccupationBestWorkTime(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
        public int BestWorkTimeId { get; set; }
        public BestWorkTime BestWorkTime { get; set; }
        public int OccupationId { get; set; }
        public Occupation Occupation { get; set; }
    }
}
