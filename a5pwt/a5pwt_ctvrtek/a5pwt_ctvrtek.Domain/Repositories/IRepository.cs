using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
        IList<TEntity> GetAll();
        IList<TEntity> GetAll(Func<TEntity, bool> predicate);
        TEntity Get(Func<TEntity, bool> predicate);
    }
}
