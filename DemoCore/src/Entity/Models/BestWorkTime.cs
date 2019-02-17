using DemoCore.Domain.Core.Models;
using System.Collections.Generic;

namespace DemoCore.Domain.Models
{
    public class BestWorkTime: Entity
    {
        public BestWorkTime(): this(0)
        {

        }
        public BestWorkTime(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
        public string DescriptionPT { get; set; }
        public string DescriptionEN { get; set; }
        public ICollection<OccupationBestWorkTime> Occupation { get; set; }
        public override bool Validate()
        {
            //TODO Implement Validate
            return true;

        }
    }
}
