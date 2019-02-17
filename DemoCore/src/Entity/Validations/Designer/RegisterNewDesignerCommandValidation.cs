using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class RegisterNewDesignerCommandValidation : DesignerValidation<RegisterNewDesignerCommand>
    {
        public RegisterNewDesignerCommandValidation()
        {
            ValidateDesigner();
        }
    }
}
