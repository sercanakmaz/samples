using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain.Client
{
    public class GenericRepository<TEntity> : IDisposable
        where TEntity: class
    {
        protected StockChainContext Context { get; set; }
        protected DbSet<TEntity> Set { get; set; }

        public GenericRepository()
        {
            this.Context = new StockChainContext();

            this.Set = this.Context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.Set.Add(entity);

            this.Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
