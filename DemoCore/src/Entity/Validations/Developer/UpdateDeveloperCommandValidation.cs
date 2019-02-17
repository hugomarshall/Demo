using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class UpdateDeveloperCommandValidation: DeveloperValidation<UpdateDeveloperCommand>
    {
        public UpdateDeveloperCommandValidation()
        {
            ValidateDeveloper();
        }
    }
}
