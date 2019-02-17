using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class UpdateDesignerCommandValidation: DesignerValidation<UpdateDesignerCommand>
    {
        public UpdateDesignerCommandValidation()
        {
            ValidateDesigner();
        }
    }
}
