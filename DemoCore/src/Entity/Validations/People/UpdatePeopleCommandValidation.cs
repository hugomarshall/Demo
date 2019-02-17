using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class UpdatePeopleCommandValidation: PeopleValidation<UpdatePeopleCommand>
    {
        public UpdatePeopleCommandValidation()
        {
            ValidatePeople();
        }
    }
}
