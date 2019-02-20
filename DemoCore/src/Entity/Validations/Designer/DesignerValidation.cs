using DemoCore.Domain.Commands;
using FluentValidation;

namespace DemoCore.Domain.Validations
{
    public class DesignerValidation<T>: AbstractValidator<T> where T: DesignerCommand
    {
        protected void ValidateDesigner()
        {
            RuleFor(x => x.DescriptionEN).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.DescriptionPT).NotEmpty().WithMessage("{PropertyName} is required.");
        }

        protected void ValidateRemove()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
