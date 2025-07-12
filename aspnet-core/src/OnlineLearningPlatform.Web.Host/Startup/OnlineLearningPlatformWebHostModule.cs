using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OnlineLearningPlatform.Configuration;

namespace OnlineLearningPlatform.Web.Host.Startup
{
    [DependsOn(
       typeof(OnlineLearningPlatformWebCoreModule))]
    public class OnlineLearningPlatformWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public OnlineLearningPlatformWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OnlineLearningPlatformWebHostModule).GetAssembly());
        }
    }
}
