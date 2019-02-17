using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class RegisterNewPeopleCommandValidation: PeopleValidation<RegisterNewPeopleCommand>
    {
        public RegisterNewPeopleCommandValidation()
        {
            ValidatePeople();
        }

    }
}
