using System;
using System.Linq;
using System.Linq.Expressions;

namespace DemoCore.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeExpressions);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        //void Remove(int id);
        void Remove(TEntity obj);
        int SaveChanges();
    }
}
