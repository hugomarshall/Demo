using DemoCore.Domain.Commands;
using FluentValidation;

namespace DemoCore.Domain.Validations
{
    public class QuestionValidation<T>: AbstractValidator<T> where T: QuestionCommand
    {
        protected void ValidateQuestion()
        {
            RuleFor(x => x.DescriptionEN).NotEmpty().WithMessage("");
            RuleFor(x => x.DescriptionPT).NotEmpty();
            RuleFor(x => x.EntityState).NotEmpty();
        }
    }
}
