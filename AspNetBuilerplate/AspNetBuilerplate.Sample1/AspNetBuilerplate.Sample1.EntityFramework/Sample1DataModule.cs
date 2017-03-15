using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using AspNetBuilerplate.Sample1.EntityFramework;

namespace AspNetBuilerplate.Sample1
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(Sample1CoreModule))]
    public class Sample1DataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Sample1DbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
