using DemoCore.Domain.Validations;

namespace DemoCore.Domain.Commands
{
    public class RemovePeopleCommand : PeopleCommand
    {
        public RemovePeopleCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemovePeopleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
