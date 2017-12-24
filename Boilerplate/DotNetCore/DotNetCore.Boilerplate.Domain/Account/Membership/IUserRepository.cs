using DotNetCore.Boilerplate.Core.Repository;
using DotNetCore.Boilerplate.Domain.Entities.Account.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Boilerplate.Domain.Account.Membership
{
    public interface IUserRepository : IGenericRepository<User, string>
    {
        User GetByUserName(string userName);
    }
}
