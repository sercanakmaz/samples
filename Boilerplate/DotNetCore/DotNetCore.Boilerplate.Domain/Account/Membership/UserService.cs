using DotNetCore.Boilerplate.Core.Service;
using DotNetCore.Boilerplate.Domain.Entities.Account.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Boilerplate.Domain.Account.Membership
{
    public class UserService : GenericService<IUserRepository, User, string>
    {
        public UserService()
        {
        }
    }
}
