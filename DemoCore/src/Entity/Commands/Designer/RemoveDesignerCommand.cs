using DemoCore.Domain.Validations;

namespace DemoCore.Domain.Commands
{
    public class RemoveDesignerCommand : DesignerCommand
    {
        public RemoveDesignerCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveDesignerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
