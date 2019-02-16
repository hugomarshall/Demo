using DemoCore.Domain.Models;
using DemoCore.Domain.Validations;
using System;
using System.Collections.Generic;

namespace DemoCore.Domain.Commands
{
    public class UpdateKnowledgeCommand : KnowledgeCommand
    {
        public UpdateKnowledgeCommand(int id, List<KnowledgeDesigner> knowledgeDesigner, List<KnowledgeDeveloper> knowledgeDeveloper, string other, string urlLink)
        {
            Id = id;
            KnowledgeDesigner = knowledgeDesigner;
            KnowledgeDeveloper = knowledgeDeveloper;
            Other = other;
            UrlLinkCRUD = urlLink;
            DateLastUpdate = DateTime.UtcNow;
            IsNew = false;
            HasChanges = true;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateKnowledgeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
