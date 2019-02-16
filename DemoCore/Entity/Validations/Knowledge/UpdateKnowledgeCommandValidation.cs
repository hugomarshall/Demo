using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class UpdateKnowledgeCommandValidation: KnowledgeValidation<UpdateKnowledgeCommand>
    {
        public UpdateKnowledgeCommandValidation()
        {
            ValidateKnowledge();
        }
    }
}
