using Abp.MultiTenancy;
using AspNetBuilerplate.Sample1.Users;

namespace AspNetBuilerplate.Sample1.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}