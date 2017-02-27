using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;

namespace Dapper.Sample1
{
    public class CategoryRepository : Repository<Categories, int>
    {
        protected override IFieldPredicate KeyPredicate(int key)
        {
            return Predicates.Field<Categories>(p => p.CategoryID, Operator.Eq, key);
        }

        protected override IFieldPredicate KeyPredicate(Categories entity)
        {
            return Predicates.Field<Categories>(p => p.CategoryID, Operator.Eq, entity.CategoryID);
        }
    }
}
