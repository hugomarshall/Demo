using DemoCore.Domain.Validations;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class UpdateQuestionCommand : QuestionCommand
    {
        public UpdateQuestionCommand(int id, string descriptionPT, string descriptionEN, EntityStateOptions entityState)
        {
            Id = id;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
            EntityState = entityState;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateQuestionCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
