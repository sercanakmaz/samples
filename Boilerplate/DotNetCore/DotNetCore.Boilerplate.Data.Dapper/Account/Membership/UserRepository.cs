using DotNetCore.Boilerplate.Domain.Account.Membership;
using System;
using System.Collections.Generic;
using System.Text;
using DotNetCore.Boilerplate.Domain.Entities.Account.Membership;
using DotNetCore.Boilerplate.Data.Dapper.Context;
using System.Linq;

namespace DotNetCore.Boilerplate.Data.Dapper.Account.Membership
{
    public class UserRepository : GenericRepository<User, string>, IUserRepository
    {
        public UserRepository(CommonContext context)
            : base(context)
        {
        }

        public virtual User GetByUserName(string userName)
        {
            var result = this.DbSet.FirstOrDefault(p => p.UserName == userName);

            return result;
        }
    }
}
