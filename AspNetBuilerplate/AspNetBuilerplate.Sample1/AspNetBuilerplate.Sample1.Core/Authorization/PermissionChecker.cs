using Abp.Authorization;
using AspNetBuilerplate.Sample1.Authorization.Roles;
using AspNetBuilerplate.Sample1.MultiTenancy;
using AspNetBuilerplate.Sample1.Users;

namespace AspNetBuilerplate.Sample1.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
