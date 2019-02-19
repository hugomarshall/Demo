using DemoCore.Domain.Validations;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class RegisterNewWorkAvailabilityCommand : WorkAvailabilityCommand
    {
        public RegisterNewWorkAvailabilityCommand(string descriptionEN, string descriptionPT)
        {
            Id = 0;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterWorkAvailabilityCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
