using DemoCore.Domain.Models;
using DemoCore.Domain.Validations;
using System;
using System.Collections.Generic;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class RegisterNewKnowledgeCommand: KnowledgeCommand
    {
        public RegisterNewKnowledgeCommand(int peopleId, List<KnowledgeDesigner> knowledgeDesigner, List<KnowledgeDeveloper> knowledgeDeveloper, string other, string urlLink) 
        {
            Id = 0;
            PeopleId = peopleId;
            KnowledgeDesigner = knowledgeDesigner;
            KnowledgeDeveloper = knowledgeDeveloper;
            Other = other;
            UrlLinkCRUD = urlLink;
            EntityState = EntityStateOptions.Active;
            DateCreated = DateTime.UtcNow;
            DateLastUpdate = DateTime.UtcNow;
            IsNew = true;
            HasChanges = false;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewKnowledgeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
