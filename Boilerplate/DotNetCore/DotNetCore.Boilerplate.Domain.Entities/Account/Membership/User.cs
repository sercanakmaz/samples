using DotNetCore.Boilerplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Boilerplate.Domain.Entities.Account.Membership
{
    public class User : GenericEntity<string>
    {
        public User()
        {
            
        }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
    }
}
