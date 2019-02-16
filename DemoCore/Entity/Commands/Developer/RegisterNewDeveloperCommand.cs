using DemoCore.Domain.Validations;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class RegisterNewDeveloperCommand : DeveloperCommand
    {
        public RegisterNewDeveloperCommand(string descriptionPT, string descriptionEN, EntityStateOptions entityState)
        {
            Id = 0;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
            EntityState = entityState;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewDeveloperCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
