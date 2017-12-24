using DotNetCore.Boilerplate.Core.Entities;
using DotNetCore.Boilerplate.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Boilerplate.Core.Service
{
    public class GenericService<TRepository, TEntity, TKey> : IGenericService<TRepository, TEntity, TKey>
         where TRepository : IGenericRepository<TEntity, TKey>
         where TEntity : class, IGenericEntity<TKey>
    {
        public TEntity GetByKey(TKey key)
        {
            var repository = IocManager.Resolve<TRepository>();

            var result = repository.GetByKey(key);

            return result;
        }

        public List<TEntity> GetList()
        {
            throw new NotImplementedException();
        }

        public TEntity Save(TEntity entity)
        {
            var repository = IocManager.Resolve<TRepository>();

            var result = repository.Save(entity);

            return result;
        }
    }
}
