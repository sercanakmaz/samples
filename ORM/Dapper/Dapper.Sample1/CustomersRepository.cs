﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;

namespace Dapper.Sample1
{
    public class CustomersRepository : Repository<Customers, string>
    {
        public override IFieldPredicate KeyPredicate(string key)
        {
            return Predicates.Field<Customers>(p => p.CustomerID, Operator.Eq, key);
        }

        public override IFieldPredicate KeyPredicate(Customers entity)
        {
            return Predicates.Field<Customers>(p => p.CustomerID, Operator.Eq, entity.CustomerID);
        }
    }
}
