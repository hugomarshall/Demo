using DemoCore.Domain.Validations;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class UpdateWorkAvailabilityCommand : WorkAvailabilityCommand
    {
        public UpdateWorkAvailabilityCommand(int id, string descriptionEN, string descriptionPT, EntityStateOptions entityState)
        {
            Id = id;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
            EntityState = entityState;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateWorkAvailabilityCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
