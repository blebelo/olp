using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OnlineLearningPlatform.Authorization;

namespace OnlineLearningPlatform
{
    [DependsOn(
        typeof(OnlineLearningPlatformCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class OnlineLearningPlatformApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<OnlineLearningPlatformAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(OnlineLearningPlatformApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
