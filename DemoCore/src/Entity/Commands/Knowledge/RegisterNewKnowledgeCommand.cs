using DemoCore.Domain.Models;
using DemoCore.Domain.Validations;
using System;
using System.Collections.Generic;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class RegisterNewKnowledgeCommand: KnowledgeCommand
    {
        public RegisterNewKnowledgeCommand(People people, List<KnowledgeDesigner> knowledgeDesigner, List<KnowledgeDeveloper> knowledgeDeveloper, string other, string urlLink) 
        {
            Id = 0;
            People = people;
            PeopleId = people.Id;
            KnowledgeDesigner = knowledgeDesigner;
            KnowledgeDeveloper = knowledgeDeveloper;
            Other = other;
            UrlLinkCRUD = urlLink;
            EntityState = EntityStateOptions.Active;
            DateCreated = DateTime.UtcNow;
            DateLastUpdate = null;
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
