using System.Linq;
using AspNetBuilerplate.Sample1.EntityFramework;
using AspNetBuilerplate.Sample1.MultiTenancy;

namespace AspNetBuilerplate.Sample1.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly Sample1DbContext _context;

        public DefaultTenantCreator(Sample1DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
