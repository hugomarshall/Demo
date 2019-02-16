using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class RegisterNewKnowledgeCommandValidation : KnowledgeValidation<RegisterNewKnowledgeCommand>
    {
        public RegisterNewKnowledgeCommandValidation()
        {
            ValidateKnowledge();
        }
    }
}
