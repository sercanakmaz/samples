using DotNetCore.Boilerplate.Core.Entities;
using DotNetCore.Boilerplate.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Boilerplate.Core.Service
{
    public interface IGenericService<TRepository, TEntity, TKey>
        where TRepository: IGenericRepository<TEntity,TKey>
        where TEntity: class, IGenericEntity<TKey>
    {
        TEntity Save(TEntity entity);
        TEntity GetByKey(TKey key);
        List<TEntity> GetList();
    }
}
