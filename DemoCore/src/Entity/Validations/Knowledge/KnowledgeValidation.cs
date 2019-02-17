using DemoCore.Domain.Commands;
using FluentValidation;

namespace DemoCore.Domain.Validations
{
    public class KnowledgeValidation<T>: AbstractValidator<T> where T: KnowledgeCommand
    {
        protected void ValidateKnowledge()
        {
            //TODO ValidateKnowledge
        }
    }
}
