using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using AspNetBuilerplate.Sample1.EntityFramework;

namespace AspNetBuilerplate.Sample1.Migrator
{
    [DependsOn(typeof(Sample1DataModule))]
    public class Sample1MigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<Sample1DbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}