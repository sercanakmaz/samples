using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Sample1
{
    public abstract class Repository<TEntity, TEntityKey> : IRepository<TEntity, TEntityKey> where TEntity : class
    {
        protected TReturn UseDbConnection<TReturn>(Func<IDbConnection, TReturn> action)
        {
            using (var connection = JohnsonNet.JohnsonManager.Config.Current.GetConnection("LocalSqlServer"))
            {
                connection.Open();
                var result = action(connection);
                connection.Close();

                return result;
            }
        }
        protected abstract IFieldPredicate KeyPredicate(TEntity entity);
        protected abstract IFieldPredicate KeyPredicate(TEntityKey key);
        public TEntity GetByID(TEntityKey key)
        {
            var result = UseDbConnection((conn) =>
            {
                return conn.Get<TEntity>(key);
            });

            return result;
        }
        public int Insert(TEntity entity)
        {
            var result = UseDbConnection((conn) =>
            {
                return conn.Insert(entity);
            });

            return result;
        }
        public bool Update(TEntity entity)
        {
            var result = UseDbConnection((conn) =>
            {
                return conn.Update(entity);
            });

            return result;
        }
        public int Save(TEntity entity)
        {
            var result = UseDbConnection((conn) =>
            {
                var existsPred = Predicates.Exists<TEntity>(KeyPredicate(entity));
                var existingUser = conn.GetList<TEntity>(existsPred).FirstOrDefault();

                if (existingUser != null)
                {
                    return Update(entity) ? 1 : 0;
                }

                return Insert(entity);
            });

            return result;
        }
        public bool Delete(TEntityKey key)
        {
            var result =  UseDbConnection((conn) =>
            {
                return conn.Delete<TEntity>(KeyPredicate(key));
            });

            return result;
        }
    }
}
