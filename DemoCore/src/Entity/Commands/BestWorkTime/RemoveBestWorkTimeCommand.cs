using DemoCore.Domain.Validations;

namespace DemoCore.Domain.Commands
{
    public class RemoveBestWorkTimeCommand: BestWorkTimeCommand
    {
        public RemoveBestWorkTimeCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveBestWorkTimeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
