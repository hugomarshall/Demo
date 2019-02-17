using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Application.ViewModels
{
    public class DeveloperVM
    {
        public int Id { get; set; }
        public string DescriptionEN { get; set; }
        public string DescriptionPT { get; set; }
        public EntityStateOptions EntityState { get; set; }
        //public ICollection<KnowledgeDeveloperVM> Knowledge { get; set; }
    }
}
