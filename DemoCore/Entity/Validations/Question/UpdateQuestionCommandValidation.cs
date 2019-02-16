using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    class UpdateQuestionCommandValidation: QuestionValidation<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidation()
        {
            ValidateQuestion();
        }
    }
}
