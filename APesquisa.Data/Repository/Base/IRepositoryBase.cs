using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace APesquisa.Data.Repository.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddAll(List<TEntity> entity);

        void Edit(TEntity entity);

        void EditAll(List<TEntity> entity);

        void Delete(TEntity entity);

        void DeleteAll(Expression<Func<TEntity, bool>> filter = null);

        List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
