using DemoCore.Domain.Validations;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class RegisterQuestionCommand : QuestionCommand
    {
        public RegisterQuestionCommand(string descriptionPT, string descriptionEN, EntityStateOptions entityState)
        {
            Id = 0;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
            EntityState = entityState;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterQuestionCommandValidation().Validate(this);
            return ValidationResult.IsValid;

        }
    }
}
