using DemoCore.Domain.Commands;
using FluentValidation;

namespace DemoCore.Domain.Validations
{
    public class PeopleValidation<T>: AbstractValidator<T> where T: PeopleCommand
    {
        protected void ValidatePeople()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Skype).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.LinkedIn).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.State).NotEmpty().WithMessage("{PropertyName} is required.");
            
        }

        protected void ValidateRemove()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
