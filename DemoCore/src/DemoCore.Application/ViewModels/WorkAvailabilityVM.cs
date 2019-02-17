using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Application.ViewModels
{
    public class WorkAvailabilityVM
    {
        public int Id { get; private set; }
        public string DescriptionEN { get; set; }
        public string DescriptionPT { get; set; }
        public EntityStateOptions EntityState { get; set; }

    }
}
