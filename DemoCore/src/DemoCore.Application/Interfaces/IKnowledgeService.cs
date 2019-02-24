using DemoCore.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace DemoCore.Application.Interfaces
{
    public interface IKnowledgeService: IDisposable
    {
        void Register(KnowledgeVM request);
        IEnumerable<KnowledgeVM> GetAll();
        KnowledgeVM GetById(int id);
        void Update(KnowledgeVM request);
        void Remove(int id);
        KnowledgeVM GetKnowledgeIncludeChilds(int id);
        void UpdateKnowledgeDesigner(string[] selectedDesigner, KnowledgeVM knowledgeToUpdate);
        void UpdateKnowledgeDeveloper(string[] selectedDeveloper, KnowledgeVM knowledgeToUpdate);
    }
}
