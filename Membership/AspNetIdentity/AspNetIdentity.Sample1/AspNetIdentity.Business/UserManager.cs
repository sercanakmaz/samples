using AspNetIdentity.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using AspNetIdentity.Data;

namespace AspNetIdentity.Business
{
    public class UserManager : Microsoft.AspNet.Identity.UserManager<User, int>
    {
        public UserManager()
            : base(new UserStore())
        {
        }
    }
}
