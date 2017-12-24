using DotNetCore.Boilerplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Boilerplate.Core.Repository
{
    public interface IGenericRepository<TEntity,TKey>
        where TEntity: class, IGenericEntity<TKey>
    {
        TEntity Save(TEntity entity);
        TEntity GetByKey(TKey key);
        List<TEntity> GetList();
    }
}
