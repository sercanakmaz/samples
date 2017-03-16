using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using AspNetBuilerplate.Sample1.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace AspNetBuilerplate.Sample1.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Sample1.EntityFramework.Sample1DbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Sample1";
        }

        protected override void Seed(Sample1.EntityFramework.Sample1DbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
