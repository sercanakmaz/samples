using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Sample1
{
    public interface IRepository<TEntity, TEntityKey> where TEntity : class
    {
        TEntity GetByID(TEntityKey key);
        int Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntityKey key);
    }
}
