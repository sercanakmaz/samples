using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace AspNetBuilerplate.Sample1.EntityFramework.Repositories
{
    public abstract class Sample1RepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<Sample1DbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected Sample1RepositoryBase(IDbContextProvider<Sample1DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class Sample1RepositoryBase<TEntity> : Sample1RepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected Sample1RepositoryBase(IDbContextProvider<Sample1DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
