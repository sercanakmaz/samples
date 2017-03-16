using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace AspNetBuilerplate.Sample1
{
    [DependsOn(typeof(Sample1CoreModule), typeof(AbpAutoMapperModule))]
    public class Sample1ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
