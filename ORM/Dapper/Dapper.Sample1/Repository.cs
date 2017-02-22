using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using JohnsonNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Sample1
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IDbConnection Connection
        {
            get
            {
                var connection = JohnsonManager.Config.Current.GetConnection("LocalSqlServer");
                connection.Open();

                return connection;
            }
        }

        public bool Delete(IEnumerable<TEntity> list)
        {
            List<bool> results = new List<bool>();

            foreach (var item in list)
            {
                Connection.Delete(item);
            }

            return results.All(p => p);
        }

        public bool Delete(TEntity obj)
        {
            return Connection.Delete(obj);
        }

        public bool DeleteAll()
        {
            return Connection.DeleteAll<TEntity>();
        }

        public TEntity Get(dynamic id)
        {
            var result = SqlMapperExtensions.Get<TEntity>(Connection, id);

            return result;
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(IEnumerable<TEntity> list)
        {
            throw new NotImplementedException();
        }

        public int Insert(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(IEnumerable<TEntity> list)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
