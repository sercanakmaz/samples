using System.Data.Common;
using Abp.Zero.EntityFramework;
using AspNetBuilerplate.Sample1.Authorization.Roles;
using AspNetBuilerplate.Sample1.MultiTenancy;
using AspNetBuilerplate.Sample1.Users;

namespace AspNetBuilerplate.Sample1.EntityFramework
{
    public class Sample1DbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public Sample1DbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in Sample1DataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of Sample1DbContext since ABP automatically handles it.
         */
        public Sample1DbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public Sample1DbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
