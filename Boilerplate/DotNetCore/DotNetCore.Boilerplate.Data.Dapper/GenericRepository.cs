using DotNetCore.Boilerplate.Core.Entities;
using DotNetCore.Boilerplate.Core.Repository;
using DotNetCore.Boilerplate.Data.Dapper.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DotNetCore.Boilerplate.Data.Dapper
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : class, IGenericEntity<TKey>
    {
        public CommonContext Context { get; set; }
        public DbSet<TEntity> DbSet { get; set; }

        public GenericRepository(CommonContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetByKey(TKey key)
        {
            var result = this.DbSet.FirstOrDefault(p => p.Id.Equals(key));

            return result;
        }

        public virtual List<TEntity> GetList()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Save(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
