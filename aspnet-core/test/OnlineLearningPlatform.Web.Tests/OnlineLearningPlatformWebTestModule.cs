using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OnlineLearningPlatform.EntityFrameworkCore;
using OnlineLearningPlatform.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace OnlineLearningPlatform.Web.Tests
{
    [DependsOn(
        typeof(OnlineLearningPlatformWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class OnlineLearningPlatformWebTestModule : AbpModule
    {
        public OnlineLearningPlatformWebTestModule(OnlineLearningPlatformEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OnlineLearningPlatformWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(OnlineLearningPlatformWebMvcModule).Assembly);
        }
    }
}