using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class RegisterQuestionCommandValidation: QuestionValidation<RegisterQuestionCommand>
    {
        public RegisterQuestionCommandValidation()
        {
            ValidateQuestion();
        }
    }
}
