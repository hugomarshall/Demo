using DemoCore.Domain.Validations;

namespace DemoCore.Domain.Commands
{
    public class RemoveWorkAvailabilityCommand : WorkAvailabilityCommand
    {
        public RemoveWorkAvailabilityCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveWorkAvailabilityCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
