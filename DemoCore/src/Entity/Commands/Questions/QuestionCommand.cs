using DemoCore.Domain.Core.Commands;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public abstract class QuestionCommand: Command
    {
        public int Id { get; set; }
        public string DescriptionPT { get; set; }
        public string DescriptionEN { get; set; }
        public EntityStateOptions EntityState { get; set; }

    }
}
