using DemoCore.Domain.Validations;

namespace DemoCore.Domain.Commands
{
    public class RemoveDeveloperCommand : DeveloperCommand
    {
        public RemoveDeveloperCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveDeveloperCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
