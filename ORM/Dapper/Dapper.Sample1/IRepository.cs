using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Sample1
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(dynamic id);
        IEnumerable<TEntity> GetAll();
        int Insert(TEntity obj);
        int Insert(IEnumerable<TEntity> list);
        bool Update(TEntity obj);
        bool Update(IEnumerable<TEntity> list);
        bool Delete(TEntity obj);
        bool Delete(IEnumerable<TEntity> list);
        bool DeleteAll();
    }
}
