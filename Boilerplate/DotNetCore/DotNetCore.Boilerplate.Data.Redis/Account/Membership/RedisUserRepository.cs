using DotNetCore.Boilerplate.Domain.Entities.Account.Membership;
using System;
using System.Collections.Generic;
using System.Text;
using DotNetCore.Boilerplate.Data.Dapper.Context;

namespace DotNetCore.Boilerplate.Data.Redis.Account.Membership
{
    public class RedisUserRepository : Dapper.Account.Membership.UserRepository
    {
        public RedisUserRepository(CommonContext context) : base(context)
        {
        }

        public override User GetByUserName(string userName)
        {
            return base.GetByUserName(userName);
        }

        public override User Save(User entity)
        {
            return base.Save(entity);
        }
    }
}
