using DemoCore.Domain.Validations;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class RegisterNewBestWorkTimeCommand : BestWorkTimeCommand
    {
        public RegisterNewBestWorkTimeCommand(string descriptionPT, string descriptionEN)
        {
            Id = 0;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewBestWorkTimeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
