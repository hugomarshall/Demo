using DemoCore.Domain.Commands;
using FluentValidation;

namespace DemoCore.Domain.Validations
{
    public class PeopleValidation<T>: AbstractValidator<T> where T: PeopleCommand
    {
        protected void ValidateName()
        {

        }

        protected void ValidateEmail()
        {

        }

        protected void ValidatePeople()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("");
            RuleFor(x => x.Email).NotEmpty().WithMessage("");
            RuleFor(x => x.Skype).NotEmpty().WithMessage("");
            RuleFor(x => x.Celular).NotEmpty().WithMessage("");
            RuleFor(x => x.LinkedIn).NotEmpty().WithMessage("");
            RuleFor(x => x.Cidade).NotEmpty().WithMessage("");
            RuleFor(x => x.Estado).NotEmpty().WithMessage("");
            RuleFor(x => x.Portfolio).Null();
        }
    }
}
