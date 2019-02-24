using DemoCore.Domain.Interfaces;
using DemoCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DemoCore.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DemoCoreContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DemoCoreContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = DbSet.Where(predicate);
            return query;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions
                  .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                    (DbSet, (current, expression) => current.Include(expression));
                return set.Where(predicate);
            }
            return Get(predicate);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(DbSet.Find(obj));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
