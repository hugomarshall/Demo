using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class RegisterNewDeveloperCommandValidation: DeveloperValidation<RegisterNewDeveloperCommand>
    {
        public RegisterNewDeveloperCommandValidation()
        {
            ValidateDeveloper();    
        }

        
    }
}
